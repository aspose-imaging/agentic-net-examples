using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

namespace AsposeImagingKernelConfig
{
    // Represents a kernel matrix configuration
    public class KernelConfig
    {
        // Dictionary where key is kernel name and value is the flat matrix values
        public Dictionary<string, double[]> Kernels { get; set; } = new Dictionary<string, double[]>();
    }

    class Program
    {
        static void Main()
        {
            // Hard‑coded paths (no argument validation)
            string outputPath = "Config/kernelConfig.json";

            try
            {
                // Ensure the output directory exists (unconditional)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Build the configuration object with custom kernels
                var config = new KernelConfig();

                // Example custom kernels (flat arrays, row‑major order)
                config.Kernels["CustomEmboss3x3"] = new double[]
                {
                    -2, -1, 0,
                    -1,  1, 1,
                     0,  1, 2
                };

                config.Kernels["CustomSharpen5x5"] = new double[]
                {
                    0, -1, -1, -1, 0,
                    -1, 2, -4, 2, -1,
                    -1, -4, 13, -4, -1,
                    -1, 2, -4, 2, -1,
                    0, -1, -1, -1, 0
                };

                // Serialize to JSON with indentation for readability
                var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(config, jsonOptions);

                // Save the JSON configuration file
                File.WriteAllText(outputPath, json);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}