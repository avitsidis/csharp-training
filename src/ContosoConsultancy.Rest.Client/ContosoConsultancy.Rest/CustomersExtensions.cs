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
    /// Extension methods for Customers.
    /// </summary>
    public static partial class CustomersExtensions
    {
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static IList<ContosoConsultancyRestModelsCustomersCustomerModel> GetAllCustomers(this ICustomers operations)
            {
                return Task.Factory.StartNew(s => ((ICustomers)s).GetAllCustomersAsync(), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IList<ContosoConsultancyRestModelsCustomersCustomerModel>> GetAllCustomersAsync(this ICustomers operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetAllCustomersWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}
