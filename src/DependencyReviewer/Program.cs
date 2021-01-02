using System;
using System.Threading;
using Spectre.Console;
using AsperandLabs.UnitStrap.Core;
using Microsoft.Extensions.DependencyInjection;
using Tests.Model;

namespace DependencyReviewer
{
    class Program
    {

        private static RegistrationAnalysis RunExampleReport()
        {
            var unitstrapper = new UnitStrapperContainer("Tests");
            var serviceCollection = unitstrapper.AddScoped<ITestWriter, TestWriter>();
            var provider = serviceCollection.BuildServiceProvider();
            var analysis = unitstrapper.AnalyzeRegistrations(provider);
            return analysis;
        }

        static void Main(string[] args)
        {

            AnsiConsole.MarkupLine("[blue]Unit Strapper is running for the Tests project[/]");


            AnsiConsole.Status()
    .Spinner(Spinner.Known.Star)
    .Start("Thinking...", ctx => {
        Thread.Sleep(3000);
    });

            var analysis = RunExampleReport();

            AnsiConsole.Progress()
                .Start(ctx =>
                {
                    // Define tasks
                    var task1 = ctx.AddTask("[green]Evaluating dependencies[/]");
                    Thread.Sleep(3000);
                    var task2 = ctx.AddTask("[green]Preparing dependency report[/]");
                    Thread.Sleep(3000);
                    while (!ctx.IsFinished)
                    {
                        task1.Increment(1.5);
                        task2.Increment(0.5);
                    }
                });

            AnsiConsole.MarkupLine("[blue]Now Viewing Dependency Report[/]");
            Thread.Sleep(2000);
            AnsiConsole.MarkupLine($"[red]There are {analysis.InScopeRegisteredTypes.Count} In Scope Registered Types[/]");
            AnsiConsole.MarkupLine($"[red]There are {analysis.InScopeUnregisteredTypes.Count} In Scope Unregistered Types[/]");
            AnsiConsole.MarkupLine($"[red]There are {analysis.InScopeUnusedRegisteredTypes.Count} In Scope Unused Registered Types[/]");
            AnsiConsole.MarkupLine($"[red]There are {analysis.OutOfScopeUnregisteredTypes.Count} Out Of Scope Unregistered Types[/]");
            AnsiConsole.MarkupLine($"[red]There are {analysis.OutOfScopeRegisteredTypes.Count} Out Of Scope Registered Types[/]");
            AnsiConsole.MarkupLine($"[red]There are {analysis.OutOfScopeUnusedRegisteredTypes.Count} Out Of Scope Unused Registered Types[/]");
            Thread.Sleep(2000);
            AnsiConsole.Markup("[blue]Press any key to exit...[/]");
            Console.ReadLine();
        }
    }
}
