﻿using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FlowControlExtensions.Test
{
    [TestClass]
    public class FlowControlExtensions_IfHasValue
    {
        [TestMethod]
        public void Should_call_func_when_nullable_has_value()
        {
            var maybeInt = new int?(1);
            var result = maybeInt.IfHasValue(one => one + 1);
            result.Should().Be(2);
        }

        [TestMethod]
        public void Should_return_default_when_nullable_has_no_value()
        {
            var result = (new int?()).IfHasValue(one => one + 1);
            result.Should().Be(0);
        }

        [TestMethod]
        public void Should_continue_executing_when_nullable_has_no_value()
        {
            var result = (new int?()).IfHasValue(one => one + 1);
            result.Should().Be(0);
        }

        [TestMethod]
        public void Should_throw_exception_when_nullable_has_no_value_and_do_not_continue()
        {
            Action act = () => (new int?()).IfHasValue(one => one, doContinue: false);
            act.ShouldThrow<InvalidOperationException>();
        }

        [TestMethod]
        public void Should_return_default_alternative_when_null()
        {
            var res = (new int?()).IfHasValue(s => s.ToString(), defaultValue: string.Empty);
            res.Should().BeEmpty();
        }

    }
}
