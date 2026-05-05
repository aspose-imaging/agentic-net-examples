using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Aspose.Imaging; // Ensure Aspose.Imaging v2 is referenced

namespace KernelConfigGenerator
{
    // Represents the structure of the JSON configuration file
    public class KernelConfig
    {
        public Dictionary<string, double[][]> Kernels { get; set; } = new Dictionary<string, double[][]>();
    }

    class Program
    {
        static void Main()
        {
            // Hardcoded paths
            string inputPath = "sample.jpg"; // Example input image (not used for config generation)
            string outputPath = "config/kernels.json";

            try
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Build custom kernel definitions
                var config = new KernelConfig();

                // Example custom 3x3 sharpen kernel
                config.Kernels["CustomSharpen3x3"] = new double[][]
                {
                    new double[] { 0, -1, 0 },
                    new double[] { -1, 5, -1 },
                    new double[] { 0, -1, 0 }
                };

                // Example custom 5x5 emboss kernel
                config.Kernels["CustomEmboss5x5"] = new double[][]
                {
                    new double[] { -2, -1, 0, 1, 2 },
                    new double[] { -1, -1, 0, 1, 1 },
                    new double[] { 0, 0, 0, 0, 0 },
                    new double[] { 1, 1, 0, -1, -1 },
                    new double[] { 2, 1, 0, -1, -2 }
                };

                // Serialize to JSON with indentation for readability
                var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
                string jsonContent = JsonSerializer.Serialize(config, jsonOptions);

                // Write JSON to the output file
                File.WriteAllText(outputPath, jsonContent);

                Console.WriteLine($"Kernel configuration saved to: {outputPath}");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}