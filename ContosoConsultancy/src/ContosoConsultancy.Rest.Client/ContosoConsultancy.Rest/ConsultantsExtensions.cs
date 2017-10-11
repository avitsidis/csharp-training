﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.16.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace ContosoConsultancy.Rest.Client.ContosoConsultancyRest
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Models;

    /// <summary>
    /// Extension methods for Consultants.
    /// </summary>
    public static partial class ConsultantsExtensions
    {
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='searchname'>
            /// </param>
            /// <param name='searchfirstName'>
            /// </param>
            /// <param name='searchteamName'>
            /// </param>
            public static IList<ConsultantModel> GetConsultants(this IConsultants operations, string searchname = default(string), string searchfirstName = default(string), string searchteamName = default(string))
            {
                return Task.Factory.StartNew(s => ((IConsultants)s).GetConsultantsAsync(searchname, searchfirstName, searchteamName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='searchname'>
            /// </param>
            /// <param name='searchfirstName'>
            /// </param>
            /// <param name='searchteamName'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IList<ConsultantModel>> GetConsultantsAsync(this IConsultants operations, string searchname = default(string), string searchfirstName = default(string), string searchteamName = default(string), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetConsultantsWithHttpMessagesAsync(searchname, searchfirstName, searchteamName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='createConsultant'>
            /// </param>
            public static ConsultantModel PostConsultant(this IConsultants operations, CreateConsultantModel createConsultant)
            {
                return Task.Factory.StartNew(s => ((IConsultants)s).PostConsultantAsync(createConsultant), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='createConsultant'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<ConsultantModel> PostConsultantAsync(this IConsultants operations, CreateConsultantModel createConsultant, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.PostConsultantWithHttpMessagesAsync(createConsultant, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            public static ConsultantModel GetConsultant(this IConsultants operations, long id)
            {
                return Task.Factory.StartNew(s => ((IConsultants)s).GetConsultantAsync(id), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<ConsultantModel> GetConsultantAsync(this IConsultants operations, long id, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetConsultantWithHttpMessagesAsync(id, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            public static ConsultantModel DeleteConsultant(this IConsultants operations, long id)
            {
                return Task.Factory.StartNew(s => ((IConsultants)s).DeleteConsultantAsync(id), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<ConsultantModel> DeleteConsultantAsync(this IConsultants operations, long id, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.DeleteConsultantWithHttpMessagesAsync(id, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}
