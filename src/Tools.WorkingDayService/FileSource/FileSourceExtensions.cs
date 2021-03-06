﻿// <copyright file="FileSourceExtensions.cs" company="Corsham Science">
// Copyright (c) Corsham Science. All rights reserved.
// </copyright>

namespace CorshamScience.Tools.WorkingDayService.FileSource
{
    using System;

    /// <summary>
    /// A helper class containing extension methods for configuring a <see cref="WorkingDayServiceBuilder"/> to use a <see cref="FileNonWorkingDaySource{T}"/>.
    /// </summary>
    // ReSharper disable once UnusedMember.Global
    public static class FileSourceExtensions
    {
        /// <summary>
        /// Configures a <see cref="WorkingDayServiceBuilder"/> to use a <see cref="FileNonWorkingDaySource{T}"/> in addition to any current sources.
        /// </summary>
        /// <typeparam name="T">The type of the internal state of the <see cref="FileNonWorkingDaySource{T}"/>.</typeparam>
        /// <param name="builder">The Builder to configure.</param>
        /// <param name="filePath">The path to the file to which should be used to create the <see cref="FileNonWorkingDaySource{T}"/>'s internal state.</param>
        /// <param name="parseFileContentAction">The action to build the internal state of the <see cref="FileNonWorkingDaySource{T}"/> from the content of the file at the provided file path.</param>
        /// <param name="checkAction">The action used to determine whether a <see cref="DateTime"/> is on a Non-Working Day (based on the current state of the <see cref="FileNonWorkingDaySource{T}"/>).
        /// Should return <c>true</c> if the provided <see cref="DateTime"/> is on a Non-Working Day, and <c>false</c> if it is on a Working Day.</param>
        /// <returns>The same instance of a <see cref="WorkingDayServiceBuilder"/> using the new <see cref="FileNonWorkingDaySource{T}"/> configured with the file at the provided file path, as well as any previously configured sources.</returns>
        // ReSharper disable once UnusedMember.Global
        public static WorkingDayServiceBuilder AddFileSource<T>(this WorkingDayServiceBuilder builder, string filePath, Func<string, T> parseFileContentAction, Func<DateTime, T, bool> checkAction)
            => builder.WithSource(new FileNonWorkingDaySource<T>(filePath, parseFileContentAction, checkAction));
    }
}
