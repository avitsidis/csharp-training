﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.16.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace ContosoConsultancy.Rest.Client.ContosoConsultancyRest.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;

    public partial class ContosoConsultancyRestModelsCustomersCustomerModel
    {
        /// <summary>
        /// Initializes a new instance of the
        /// ContosoConsultancyRestModelsCustomersCustomerModel class.
        /// </summary>
        public ContosoConsultancyRestModelsCustomersCustomerModel() { }

        /// <summary>
        /// Initializes a new instance of the
        /// ContosoConsultancyRestModelsCustomersCustomerModel class.
        /// </summary>
        public ContosoConsultancyRestModelsCustomersCustomerModel(long? id = default(long?), string name = default(string), string addressLine1 = default(string), string addressLine2 = default(string))
        {
            Id = id;
            Name = name;
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Id")]
        public long? Id { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "AddressLine1")]
        public string AddressLine1 { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "AddressLine2")]
        public string AddressLine2 { get; private set; }

    }
}
