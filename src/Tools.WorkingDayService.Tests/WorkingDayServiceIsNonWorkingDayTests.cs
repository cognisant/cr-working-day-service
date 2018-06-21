﻿// <copyright file="WorkingDayServiceIsNonWorkingDayTests.cs" company="Cognisant">
// Copyright (c) Cognisant. All rights reserved.
// </copyright>

namespace CR.Tools.WorkingDayService.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    /// <summary>
    /// Tests for the Working Day Service's IsNonWorkingDay method.
    /// </summary>
    [TestFixture]
    public class WorkingDayServiceIsNonWorkingDayTests
    {
        /// <summary>
        /// Test to check that a Working Day Service which has no sources considers no Days a non-Working Day.
        /// </summary>
        [Test]
        public static void WorkingDayServiceWithNoSourcesReturnsNoDayAsNonWorkingDay() => Assert.IsFalse(new WorkingDayService(new List<NonWorkingDaySource>()).IsNonWorkingDay(DateTime.Now));

        /// <summary>
        /// Test to check that a Working Day Service with one Source considers a Working Day a Working Day.
        /// </summary>
        [Test]
        public static void WorkingDayServiceWithOneSourceReturnsFalseWhenIsWorkingDayIsNonWorkingDayCalledOnAWorkingDay() => Assert.IsTrue(new WorkingDayService(new List<NonWorkingDaySource> { new MondayNonWorkingDayTestSource() }).IsWorkingDay(new DateTime(2018, 5, 15)));

        /// <summary>
        /// Test to check that a Working Day Service with one Source considers a non-Working Day a non-Working Day.
        /// </summary>
        [Test]
        public static void WorkingDayServiceWithOneSourceReturnsTrueWhenIsNonWorkingDayIsCalledOnANonWorkingDay() => Assert.IsTrue(new WorkingDayService(new List<NonWorkingDaySource> { new MondayNonWorkingDayTestSource() }).IsNonWorkingDay(new DateTime(2018, 5, 14)));

        /// <summary>
        /// Test to check that a Working Day Service with multiple Sources only considers a date a Working Day when none of its sources consider it a non-Working Day.
        /// </summary>
        [Test]
        public static void WorkingDayServiceWithMultipleSourcesReturnsFalseForAnyDayNotConsideredAWorkingDayByAllSourcesPassedToIsNonWorkingDay()
        {
            var workingDayService = new WorkingDayService(new List<NonWorkingDaySource> { new MondayNonWorkingDayTestSource(), new TuesdayNonWorkingDayTestSource() });
            Assert.IsFalse(workingDayService.IsWorkingDay(new DateTime(2018, 5, 14)));
            Assert.IsFalse(workingDayService.IsWorkingDay(new DateTime(2018, 5, 15)));
        }

        /// <summary>
        /// Test to check that a Working Day Service with multiple Sources considers a date which is not a Working Day according to any of its sources a non-Working Day.
        /// </summary>
        [Test]
        public static void WorkingDayServiceWithMultipleSourcesReturnsTrueForAnyDayNotConsideredAWorkingDayByAtLeastOneSourcePassedToIsNonWorkingDay()
        {
            var workingDayService = new WorkingDayService(new List<NonWorkingDaySource> { new MondayNonWorkingDayTestSource(), new TuesdayNonWorkingDayTestSource() });
            Assert.IsTrue(workingDayService.IsNonWorkingDay(new DateTime(2018, 5, 14)));
            Assert.IsTrue(workingDayService.IsNonWorkingDay(new DateTime(2018, 5, 15)));
        }
    }
}
