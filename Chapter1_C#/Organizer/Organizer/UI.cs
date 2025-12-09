using System;
using System.Collections.Generic;
using System.Text;
using Spectre.Console;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;
namespace Organizer
{
    internal class UI
    {
        private readonly MissionsController _controller;
        private Table _commandsTable;
        public UI() 
        {
            _controller = new MissionsController();

            AnsiConsole.MarkupLine("[bold red on yellow blink underline]Wellcome![/] This is very [italic green on black strikethrough]important[/].");
            FillCommandsTable();
            AnsiConsole.Write(new Align(_commandsTable, HorizontalAlignment.Right, VerticalAlignment.Top));
            


            Console.ReadLine();
        }
        private void FillCommandsTable() 
        {
            _commandsTable = new Table();
            _commandsTable.Title = new TableTitle("[underline yellow]Commands[/]");
            _commandsTable.Caption = new TableTitle("[grey]Some commands that you can write[/]");

            _commandsTable.AddColumn("Comand");
            _commandsTable.AddColumn("Function");

            _commandsTable.AddRow("/TaskList","Writes list of current tasks");
            _commandsTable.AddRow("/TaslListOrderedByDate","Writes list of current tasks ordered by date");
            _commandsTable.AddRow("/GetTaskByName","Searches task by name");
        }
        private async Task LocateProgressBars() 
        {
            await AnsiConsole.Progress()
                .AutoRefresh(false)
                .AutoClear(false)
                .HideCompleted(false)
                .Columns(new ProgressColumn[] 
                {
                    new TaskDescriptionColumn(),
                    new ProgressBarColumn(),
                    new PercentageColumn(),
                    new RemainingTimeColumn(),
                    new SpinnerColumn(),
                    new DownloadedColumn(),
                    new TransferSpeedColumn()
                })
                .StartAsync(async ctx =>
                {
                    var task1 = ctx.AddTask("[yellow]VS Code RAM usage[/]");
                    
                    while (!ctx.IsFinished) 
                    {
                        await Task.Delay(100);
                        task1.Increment(2);
                    }
                });
        }
    }
}
