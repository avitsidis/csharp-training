﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.16.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace ContosoConsultancy.Rest.Client.ContosoConsultancyRest
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Newtonsoft.Json;
    using Models;

    public partial class ContosoConsultancyRestClient : ServiceClient<ContosoConsultancyRestClient>, IContosoConsultancyRestClient
    {
        /// <summary>
        /// The base URI of the service.
        /// </summary>
        public Uri BaseUri { get; set; }

        /// <summary>
        /// Gets or sets json serialization settings.
        /// </summary>
        public JsonSerializerSettings SerializationSettings { get; private set; }

        /// <summary>
        /// Gets or sets json deserialization settings.
        /// </summary>
        public JsonSerializerSettings DeserializationSettings { get; private set; }        

        /// <summary>
        /// Subscription credentials which uniquely identify client subscription.
        /// </summary>
        public ServiceClientCredentials Credentials { get; private set; }

        /// <summary>
        /// Gets the IConsultants.
        /// </summary>
        public virtual IConsultants Consultants { get; private set; }

        /// <summary>
        /// Gets the ICustomers.
        /// </summary>
        public virtual ICustomers Customers { get; private set; }

        /// <summary>
        /// Gets the IDashboard.
        /// </summary>
        public virtual IDashboard Dashboard { get; private set; }

        /// <summary>
        /// Gets the ITeams.
        /// </summary>
        public virtual ITeams Teams { get; private set; }

        /// <summary>
        /// Initializes a new instance of the ContosoConsultancyRestClient class.
        /// </summary>
        /// <param name='handlers'>
        /// Optional. The delegating handlers to add to the http client pipeline.
        /// </param>
        protected ContosoConsultancyRestClient(params DelegatingHandler[] handlers) : base(handlers)
        {
            this.Initialize();
        }

        /// <summary>
        /// Initializes a new instance of the ContosoConsultancyRestClient class.
        /// </summary>
        /// <param name='rootHandler'>
        /// Optional. The http client handler used to handle http transport.
        /// </param>
        /// <param name='handlers'>
        /// Optional. The delegating handlers to add to the http client pipeline.
        /// </param>
        protected ContosoConsultancyRestClient(HttpClientHandler rootHandler, params DelegatingHandler[] handlers) : base(rootHandler, handlers)
        {
            this.Initialize();
        }

        /// <summary>
        /// Initializes a new instance of the ContosoConsultancyRestClient class.
        /// </summary>
        /// <param name='baseUri'>
        /// Optional. The base URI of the service.
        /// </param>
        /// <param name='handlers'>
        /// Optional. The delegating handlers to add to the http client pipeline.
        /// </param>
        protected ContosoConsultancyRestClient(Uri baseUri, params DelegatingHandler[] handlers) : this(handlers)
        {
            if (baseUri == null)
            {
                throw new ArgumentNullException("baseUri");
            }
            this.BaseUri = baseUri;
        }

        /// <summary>
        /// Initializes a new instance of the ContosoConsultancyRestClient class.
        /// </summary>
        /// <param name='baseUri'>
        /// Optional. The base URI of the service.
        /// </param>
        /// <param name='rootHandler'>
        /// Optional. The http client handler used to handle http transport.
        /// </param>
        /// <param name='handlers'>
        /// Optional. The delegating handlers to add to the http client pipeline.
        /// </param>
        protected ContosoConsultancyRestClient(Uri baseUri, HttpClientHandler rootHandler, params DelegatingHandler[] handlers) : this(rootHandler, handlers)
        {
            if (baseUri == null)
            {
                throw new ArgumentNullException("baseUri");
            }
            this.BaseUri = baseUri;
        }

        /// <summary>
        /// Initializes a new instance of the ContosoConsultancyRestClient class.
        /// </summary>
        /// <param name='credentials'>
        /// Required. Subscription credentials which uniquely identify client subscription.
        /// </param>
        /// <param name='handlers'>
        /// Optional. The delegating handlers to add to the http client pipeline.
        /// </param>
        public ContosoConsultancyRestClient(ServiceClientCredentials credentials, params DelegatingHandler[] handlers) : this(handlers)
        {
            if (credentials == null)
            {
                throw new ArgumentNullException("credentials");
            }
            this.Credentials = credentials;
            if (this.Credentials != null)
            {
                this.Credentials.InitializeServiceClient(this);
            }
        }

        /// <summary>
        /// Initializes a new instance of the ContosoConsultancyRestClient class.
        /// </summary>
        /// <param name='credentials'>
        /// Required. Subscription credentials which uniquely identify client subscription.
        /// </param>
        /// <param name='rootHandler'>
        /// Optional. The http client handler used to handle http transport.
        /// </param>
        /// <param name='handlers'>
        /// Optional. The delegating handlers to add to the http client pipeline.
        /// </param>
        public ContosoConsultancyRestClient(ServiceClientCredentials credentials, HttpClientHandler rootHandler, params DelegatingHandler[] handlers) : this(rootHandler, handlers)
        {
            if (credentials == null)
            {
                throw new ArgumentNullException("credentials");
            }
            this.Credentials = credentials;
            if (this.Credentials != null)
            {
                this.Credentials.InitializeServiceClient(this);
            }
        }

        /// <summary>
        /// Initializes a new instance of the ContosoConsultancyRestClient class.
        /// </summary>
        /// <param name='baseUri'>
        /// Optional. The base URI of the service.
        /// </param>
        /// <param name='credentials'>
        /// Required. Subscription credentials which uniquely identify client subscription.
        /// </param>
        /// <param name='handlers'>
        /// Optional. The delegating handlers to add to the http client pipeline.
        /// </param>
        public ContosoConsultancyRestClient(Uri baseUri, ServiceClientCredentials credentials, params DelegatingHandler[] handlers) : this(handlers)
        {
            if (baseUri == null)
            {
                throw new ArgumentNullException("baseUri");
            }
            if (credentials == null)
            {
                throw new ArgumentNullException("credentials");
            }
            this.BaseUri = baseUri;
            this.Credentials = credentials;
            if (this.Credentials != null)
            {
                this.Credentials.InitializeServiceClient(this);
            }
        }

        /// <summary>
        /// Initializes a new instance of the ContosoConsultancyRestClient class.
        /// </summary>
        /// <param name='baseUri'>
        /// Optional. The base URI of the service.
        /// </param>
        /// <param name='credentials'>
        /// Required. Subscription credentials which uniquely identify client subscription.
        /// </param>
        /// <param name='rootHandler'>
        /// Optional. The http client handler used to handle http transport.
        /// </param>
        /// <param name='handlers'>
        /// Optional. The delegating handlers to add to the http client pipeline.
        /// </param>
        public ContosoConsultancyRestClient(Uri baseUri, ServiceClientCredentials credentials, HttpClientHandler rootHandler, params DelegatingHandler[] handlers) : this(rootHandler, handlers)
        {
            if (baseUri == null)
            {
                throw new ArgumentNullException("baseUri");
            }
            if (credentials == null)
            {
                throw new ArgumentNullException("credentials");
            }
            this.BaseUri = baseUri;
            this.Credentials = credentials;
            if (this.Credentials != null)
            {
                this.Credentials.InitializeServiceClient(this);
            }
        }

        /// <summary>
        /// An optional partial-method to perform custom initialization.
        ///</summary> 
        partial void CustomInitialize();
        /// <summary>
        /// Initializes client properties.
        /// </summary>
        private void Initialize()
        {
            this.Consultants = new Consultants(this);
            this.Customers = new Customers(this);
            this.Dashboard = new Dashboard(this);
            this.Teams = new Teams(this);
            this.BaseUri = new Uri("http://localhost:57216");
            SerializationSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                ContractResolver = new ReadOnlyJsonContractResolver(),
                Converters = new List<JsonConverter>
                    {
                        new Iso8601TimeSpanConverter()
                    }
            };
            DeserializationSettings = new JsonSerializerSettings
            {
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                ContractResolver = new ReadOnlyJsonContractResolver(),
                Converters = new List<JsonConverter>
                    {
                        new Iso8601TimeSpanConverter()
                    }
            };
            CustomInitialize();
        }    
    }
}
