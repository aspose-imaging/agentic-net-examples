// HOW-TO: Generate JSON Kernel Configuration File for Image Filters in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

namespace KernelConfigGenerator
{
    public class KernelMatrix
    {
        public string Name { get; set; }
        public double[][] Matrix { get; set; }
    }

    public class Config
    {
        public List<KernelMatrix> Kernels { get; set; }
    }

    class Program
    {
        static void Main()
        {
            try
            {
                // Hardcoded output path
                string outputPath = "config/kernels.json";

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Define custom kernel matrices
                var config = new Config
                {
                    Kernels = new List<KernelMatrix>
                    {
                        new KernelMatrix
                        {
                            Name = "Sharpen",
                            Matrix = new double[][]
                            {
                                new double[] { 0, -1, 0 },
                                new double[] { -1, 5, -1 },
                                new double[] { 0, -1, 0 }
                            }
                        },
                        new KernelMatrix
                        {
                            Name = "EdgeDetect",
                            Matrix = new double[][]
                            {
                                new double[] { -1, -1, -1 },
                                new double[] { -1, 8, -1 },
                                new double[] { -1, -1, -1 }
                            }
                        }
                    }
                };

                var options = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(config, options);
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
 * 1. When you need to supply custom sharpen and edge‑detect kernels to Aspose.Imaging at runtime without recompiling the application.
 * 2. When you want to store image processing kernels in a portable JSON file that can be edited by non‑programmers.
 * 3. When your application must load different convolution matrices based on user selection or configuration.
 * 4. When you need to ensure the output directory exists before writing the kernel configuration for a CI/CD pipeline.
 * 5. When you want to serialize a list of named double‑precision matrices to a formatted JSON file for easy debugging.
 */
