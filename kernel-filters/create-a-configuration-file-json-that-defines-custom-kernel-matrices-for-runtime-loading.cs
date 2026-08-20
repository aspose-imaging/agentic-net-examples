// HOW-TO: Generate JSON Kernel Configuration File for Custom Image Filters in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

namespace AsposeImagingKernelConfig
{
    // Represents a kernel definition that can be loaded at runtime
    public class KernelDefinition
    {
        public string Name { get; set; }
        public double[] Matrix { get; set; }
    }

    class Program
    {
        static void Main()
        {
            // Hardcoded paths
            string outputPath = @"C:\Temp\kernelConfig.json";

            try
            {
                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Define custom kernels
                var kernels = new List<KernelDefinition>
                {
                    new KernelDefinition
                    {
                        Name = "CustomSharpen3x3",
                        Matrix = new double[]
                        {
                            0, -1, 0,
                            -1, 5, -1,
                            0, -1, 0
                        }
                    },
                    new KernelDefinition
                    {
                        Name = "CustomBlur5x5",
                        Matrix = new double[]
                        {
                            1, 1, 1, 1, 1,
                            1, 1, 1, 1, 1,
                            1, 1, 1, 1, 1,
                            1, 1, 1, 1, 1,
                            1, 1, 1, 1, 1
                        }
                    }
                };

                // Serialize to JSON with indentation for readability
                var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(kernels, jsonOptions);

                // Write JSON to the output file
                File.WriteAllText(outputPath, json);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to define custom sharpening or blur kernels once and load them at runtime without recompiling the application.
 * 2. When you want to store image processing filter definitions in a portable JSON file that can be edited by non‑developers.
 * 3. When you are building a plugin system that lets end users add or modify convolution kernels without changing code.
 * 4. When you need to ensure the kernel configuration directory exists before writing the JSON file to avoid runtime errors.
 * 5. When you want to serialize multiple kernel matrices with readable indentation for easy debugging or version control.
 */
