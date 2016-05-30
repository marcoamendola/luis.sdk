using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System.Collections.Generic;
using Luis.Sdk.Contract;
using Ploeh.AutoFixture;
using FluentAssertions;
using System.Linq;
using System.Globalization;
using Luis.SDK.ClientLibrary.Tests.Fixtures;

namespace Luis.SDK.ClientLibrary.Tests
{
    [TestClass]
    public class ActionsResourceTests : TestClassWithAppBase
    {
        

        [TestMethod]
        public async Task Can_create_an_Action()
        {
            var countBefore = (await _sut.GetActionsAsync(_testAppId)).Length;

            var intent = _fixture.Freeze<Sdk.Contract.Intent>();
            var action = _fixture.Freeze<Sdk.Contract.Action>();
            var newId = await _fixture.PersistNewAction(_sut);

            var actions = await _sut.GetActionsAsync(_testAppId);
            actions.Length.Should().Be(countBefore + 1);
            var added = actions.SingleOrDefault(a => a.ID == newId);
            added.Should().NotBeNull();

            added.ID.Should().Be(newId);
            added.Name.Should().Be(action.Name);
            added.IntentName.Should().Be(intent.Name);
            added.Parameters.Should().HaveCount(3);

            added.Channel.Should().BeNull();
            added.Dialog.Should().BeNull();
        }


        [TestMethod]
        public async Task Can_update_an_Action()
        {
            var actionId = await _fixture.PersistNewAction(_sut);
            var action = await _sut.GetActionAsync(_testAppId, actionId);

            var entityName = _fixture.Create<string>();
            var entity = await _fixture.PersistNewEntity(_sut, entityName);
            var modified = _fixture.Create<Sdk.Contract.Action>();
            modified.ID = actionId;
            modified.IntentName = action.IntentName;
            modified.Parameters.Clear();
            var parameter = _fixture.Create<Sdk.Contract.ActionParameter>();
            parameter.EntityName = entityName;
            modified.Parameters.Add(parameter);
            
            await _sut.UpdateActionAsync(_testAppId, modified);

            var retrieved = await _sut.GetActionAsync(_testAppId, actionId);
            retrieved.Name.Should().Be(modified.Name);
            retrieved.Parameters.Should().HaveCount(1);
            retrieved.Parameters.First().EntityName.Should().Be(entityName);
        }

        [TestMethod]
        public async Task Can_delete_an_Action()
        {
            var countBefore = (await _sut.GetActionsAsync(_testAppId)).Length;
            var newId = await _fixture.PersistNewAction(_sut);

            await _sut.DeleteActionAsync(_testAppId, newId);

            var actions = await _sut.GetActionsAsync(_testAppId);
            actions.Length.Should().Be(countBefore);
            actions.Any(e => e.ID == newId).Should().BeFalse();
        }

        [TestMethod]
        public async Task Can_get_single_Action()
        {
            var expected = _fixture.Freeze<Sdk.Contract.Action>();
            var newId = await _fixture.PersistNewAction(_sut);

            var action = await _sut.GetActionAsync(_testAppId, newId);

            action.Should().NotBeNull();
            action.ID.Should().Be(newId);
            action.Name.Should().Be(expected.Name);
        }

        [TestMethod]
        public void Should_throw_when_getting_unexisting_Action()
        {
            var id = _fixture.Create<string>();

            _sut.Awaiting(s => s.GetActionAsync(_testAppId, id))
                .ShouldThrow<Microsoft.ProjectOxford.Common.ClientException>();
        }

        [TestMethod]
        public async Task Can_list_Actions()
        {
            await _fixture.PersistNewAction(_sut);
            var actions = (await _sut.GetActionsAsync(_testAppId)).ToArray();
            actions.Should().NotBeEmpty();
        }
    }
}
