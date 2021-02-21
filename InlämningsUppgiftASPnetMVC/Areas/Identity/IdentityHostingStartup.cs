using System;
using InlämningsUppgiftASPnetMVC.Data;
using InlämningsUppgiftASPnetMVC.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(InlämningsUppgiftASPnetMVC.Areas.Identity.IdentityHostingStartup))]
namespace InlämningsUppgiftASPnetMVC.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}