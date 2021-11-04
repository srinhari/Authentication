using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;

namespace IAMServer.Settings {
    public class IdentityServerSettings {
        public IReadOnlyCollection<ApiScope> ApiScopes { get; set; }
        public IReadOnlyCollection<ApiResource> ApiResources { get; set; }

        public IReadOnlyCollection<Client> Clients { get; set; }

        public IReadOnlyCollection<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };

    }
}
