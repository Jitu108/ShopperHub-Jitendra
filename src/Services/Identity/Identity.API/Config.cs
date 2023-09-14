// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace Identity.API
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            { 
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                new ApiResource
                {
                    Name = "Catalog.API",
                    Description = "Catalog API Services",
                    Scopes = { "CatalogAPI" }
                },
                new ApiResource
                {
                    Name = "Discount.API",
                    Description = "Discount API Services",
                    Scopes = { "DiscountAPI" }
                },
                new ApiResource
                {
                    Name = "Basket.API",
                    Description = "Basket API Services",
                    Scopes = { "BasketAPI" }
                }
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            { 
                new ApiScope
                {
                    Name = "CatalogAPI"
                },
                new ApiScope
                {
                    Name = "DiscountAPI"
                },
                new ApiScope
                {
                    Name = "BasketAPI"
                },
            };

        public static IEnumerable<Client> Clients =>
            new Client[] 
            { 
                new Client
                {
                    ClientId = "MVC.Client",
                    ClientName = "MVC Client",
                    ClientSecrets = { new Secret("Secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.Code,
                    // where to redirect to after login
                    RedirectUris = {
                        "https://localhost:4001/signin-oidc"
                    },

                    // where to redirect to after logout
                    PostLogoutRedirectUris = {
                        "https://localhost:4001/signout-callback-oidc"
                    },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "CatalogAPI",
                        "DiscountAPI",
                        "BasketAPI"
                    },
                }
            };
    }
}