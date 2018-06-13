﻿// <copyright file="StringSourceExtensions.cs" company="Cognisant">
// Copyright (c) Cognisant. All rights reserved.
// </copyright>

namespace CR.WorkingDayService.StringSource
{
    using System;

    /// <summary>
    /// An Extension Methods class containing methods for configuring a <see cref="WorkingDayServiceBuilder"/> to use <see cref="StringNonWorkingDaySource{T}"/>s.
    /// </summary>
    public static class StringSourceExtensions
    {
        /// <summary>
        /// Configures a <see cref="WorkingDayServiceBuilder"/> to only use a <see cref="StringNonWorkingDaySource{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of the internal state of the <see cref="StringNonWorkingDaySource{T}"/>.</typeparam>
        /// <param name="builder">The Builder to configure.</param>
        /// <param name="source">The path to the file who's content should be used to build the internal state of the <see cref="StringNonWorkingDaySource{T}"/>.</param>
        /// <param name="parseFileContentAction">The action used to build the internal state of the <see cref="StringNonWorkingDaySource{T}"/> from the content of the file at the provided file path.</param>
        /// <param name="checkAction">The action used to determine if a given <see cref="DateTime"/> is on a Working Day (using the <see cref="StringNonWorkingDaySource{T}"/> based on the file at the provided file path).</param>
        /// <returns>The same instance of a <see cref="WorkingDayServiceBuilder"/> only using the new <see cref="StringNonWorkingDaySource{T}"/>.</returns>
        public static WorkingDayServiceBuilder UseStringSource<T>(this WorkingDayServiceBuilder builder, string source, Func<string, T> parseFileContentAction, Func<DateTime, T, bool> checkAction)
            => builder.UseSource(new StringNonWorkingDaySource<T>(source, parseFileContentAction, checkAction));

        /// <summary>
        /// Configures a <see cref="WorkingDayServiceBuilder"/> to use a <see cref="StringNonWorkingDaySource{T}"/> in addition to its current sources.
        /// </summary>
        /// <typeparam name="T">The type of the internal state of the <see cref="StringNonWorkingDaySource{T}"/>.</typeparam>
        /// <param name="builder">The Builder to configure.</param>
        /// <param name="source">The path to the file who's content should be used to build the internal state of the <see cref="StringNonWorkingDaySource{T}"/>.</param>
        /// <param name="parseFileContentAction">The action used to build the internal state of the <see cref="StringNonWorkingDaySource{T}"/> from the content of the file at the provided file path.</param>
        /// <param name="checkAction">The action used to determine if a given <see cref="DateTime"/> is on a Working Day (using the <see cref="StringNonWorkingDaySource{T}"/> based on the file at the provided file path).</param>
        /// <returns>The same instance of a <see cref="WorkingDayServiceBuilder"/> using the new <see cref="StringNonWorkingDaySource{T}"/> in addition to its current sources.</returns>
        public static WorkingDayServiceBuilder AddStringSource<T>(this WorkingDayServiceBuilder builder, string source, Func<string, T> parseFileContentAction, Func<DateTime, T, bool> checkAction)
            => builder.AddSource(new StringNonWorkingDaySource<T>(source, parseFileContentAction, checkAction));
    }
}
