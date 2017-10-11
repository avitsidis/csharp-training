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
    /// Extension methods for Teams.
    /// </summary>
    public static partial class TeamsExtensions
    {
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            /// <param name='consultantId'>
            /// </param>
            public static ContosoConsultancyRestModelsTeamsTeamModel PostMember(this ITeams operations, long id, long consultantId)
            {
                return Task.Factory.StartNew(s => ((ITeams)s).PostMemberAsync(id, consultantId), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            /// <param name='consultantId'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<ContosoConsultancyRestModelsTeamsTeamModel> PostMemberAsync(this ITeams operations, long id, long consultantId, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.PostMemberWithHttpMessagesAsync(id, consultantId, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            /// <param name='consultantId'>
            /// </param>
            public static ContosoConsultancyRestModelsTeamsTeamModel DeleteMember(this ITeams operations, long id, long consultantId)
            {
                return Task.Factory.StartNew(s => ((ITeams)s).DeleteMemberAsync(id, consultantId), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            /// <param name='consultantId'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<ContosoConsultancyRestModelsTeamsTeamModel> DeleteMemberAsync(this ITeams operations, long id, long consultantId, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.DeleteMemberWithHttpMessagesAsync(id, consultantId, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            /// <param name='consultantId'>
            /// </param>
            public static ContosoConsultancyRestModelsTeamsTeamModel PutManager(this ITeams operations, long id, long consultantId)
            {
                return Task.Factory.StartNew(s => ((ITeams)s).PutManagerAsync(id, consultantId), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            /// <param name='consultantId'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<ContosoConsultancyRestModelsTeamsTeamModel> PutManagerAsync(this ITeams operations, long id, long consultantId, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.PutManagerWithHttpMessagesAsync(id, consultantId, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static IList<ContosoConsultancyRestModelsTeamsTeamModel> GetTeams(this ITeams operations)
            {
                return Task.Factory.StartNew(s => ((ITeams)s).GetTeamsAsync(), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IList<ContosoConsultancyRestModelsTeamsTeamModel>> GetTeamsAsync(this ITeams operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetTeamsWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='name'>
            /// </param>
            public static ContosoConsultancyRestModelsTeamsTeamModel PostTeam(this ITeams operations, string name)
            {
                return Task.Factory.StartNew(s => ((ITeams)s).PostTeamAsync(name), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='name'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<ContosoConsultancyRestModelsTeamsTeamModel> PostTeamAsync(this ITeams operations, string name, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.PostTeamWithHttpMessagesAsync(name, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            public static ContosoConsultancyRestModelsTeamsTeamModel GetTeam(this ITeams operations, long id)
            {
                return Task.Factory.StartNew(s => ((ITeams)s).GetTeamAsync(id), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<ContosoConsultancyRestModelsTeamsTeamModel> GetTeamAsync(this ITeams operations, long id, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetTeamWithHttpMessagesAsync(id, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            public static ContosoConsultancyRestModelsTeamsTeamModel DeleteTeam(this ITeams operations, long id)
            {
                return Task.Factory.StartNew(s => ((ITeams)s).DeleteTeamAsync(id), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<ContosoConsultancyRestModelsTeamsTeamModel> DeleteTeamAsync(this ITeams operations, long id, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.DeleteTeamWithHttpMessagesAsync(id, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}
