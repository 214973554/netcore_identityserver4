﻿using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer4App
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetApis()
        {
            return new List<ApiResource> { new ApiResource("api1", "my api") };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client{ ClientId="client",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                AllowedScopes={"api1"}
                },
                new Client
                {
                    ClientId="ro.client",
                    AllowedGrantTypes= GrantTypes.ResourceOwnerPassword,
                    ClientSecrets =
                    {
                        new Secret("secret_testUser".Sha256())
                    },
                    AllowedScopes={"api1"}
                }
            };
        }

        public static List<TestUser> GetTestUsers() =>
        new List<TestUser>()
            {
                new TestUser
                {
                     SubjectId="1",
                     Username="one",
                     Password="onepwd"
                },
                new TestUser
                {
                    SubjectId="2",
                    Username="two",
                    Password="twopwd"
                }
            };
    }
}
