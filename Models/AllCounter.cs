using Microsoft.Maui.Storage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counter22.Models
{
    internal class AllCounter
    {
        public ObservableCollection<Counter> counters { get; set; } = new();
        public string AddButtonText => "Add";

        public AllCounter() => LoadCounters();

        public void LoadCounters()
        {
            counters.Clear();

            var files = Directory
                .EnumerateFiles(FileSystem.AppDataDirectory, "*.note")
                .OrderBy(name => File.GetCreationTime(name));

            foreach (string name in files)
            {
                string countFile = name + ".count";

                int savedCount = 0;

                if (File.Exists(countFile))
                {
                    int.TryParse(
                        File.ReadAllText(countFile),
                        out savedCount
                    );
                }

                var counter = new Counter
                {
                    Filename = name,
                    Text = File.ReadAllText(name),
                    Date = File.GetCreationTime(name),
                    Count = savedCount
                };

                counters.Add(counter);
            }
        }

    }
}