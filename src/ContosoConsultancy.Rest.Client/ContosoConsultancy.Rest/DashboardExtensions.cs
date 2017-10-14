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
    /// Extension methods for Dashboard.
    /// </summary>
    public static partial class DashboardExtensions
    {
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static int? GetIdleEmployeeCount(this IDashboard operations)
            {
                return Task.Factory.StartNew(s => ((IDashboard)s).GetIdleEmployeeCountAsync(), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<int?> GetIdleEmployeeCountAsync(this IDashboard operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetIdleEmployeeCountWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='numberOfClients'>
            /// </param>
            public static IList<ContosoConsultancyRestModelsDashboardCustomerModel> GetTopClient(this IDashboard operations, int numberOfClients)
            {
                return Task.Factory.StartNew(s => ((IDashboard)s).GetTopClientAsync(numberOfClients), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='numberOfClients'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IList<ContosoConsultancyRestModelsDashboardCustomerModel>> GetTopClientAsync(this IDashboard operations, int numberOfClients, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetTopClientWithHttpMessagesAsync(numberOfClients, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='numberOfMissions'>
            /// </param>
            public static IList<ContosoConsultancyRestModelsDashboardMissionModel> GetNewestMission(this IDashboard operations, int numberOfMissions)
            {
                return Task.Factory.StartNew(s => ((IDashboard)s).GetNewestMissionAsync(numberOfMissions), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='numberOfMissions'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IList<ContosoConsultancyRestModelsDashboardMissionModel>> GetNewestMissionAsync(this IDashboard operations, int numberOfMissions, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetNewestMissionWithHttpMessagesAsync(numberOfMissions, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static IList<SystemCollectionsGenericKeyValuePairSystemInt32SystemInt32> GetHiredEmployeeByYear(this IDashboard operations)
            {
                return Task.Factory.StartNew(s => ((IDashboard)s).GetHiredEmployeeByYearAsync(), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IList<SystemCollectionsGenericKeyValuePairSystemInt32SystemInt32>> GetHiredEmployeeByYearAsync(this IDashboard operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetHiredEmployeeByYearWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}