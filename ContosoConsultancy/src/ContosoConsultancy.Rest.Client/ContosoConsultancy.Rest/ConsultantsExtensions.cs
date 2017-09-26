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
            public static IList<ConsultantModel> GetConsultants(this IConsultants operations)
            {
                return Task.Factory.StartNew(s => ((IConsultants)s).GetConsultantsAsync(), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IList<ConsultantModel>> GetConsultantsAsync(this IConsultants operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetConsultantsWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
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
