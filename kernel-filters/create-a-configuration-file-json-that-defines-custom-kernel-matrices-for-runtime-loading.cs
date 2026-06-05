using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;

namespace KernelConfigGenerator
{
    // Represents a single kernel definition
    public class KernelDefinition
    {
        // Name of the kernel (e.g., "CustomEmboss3x3")
        public string Name { get; set; } = string.Empty;

        // 2‑dimensional matrix values
        public double[][] Matrix { get; set; } = Array.Empty<double[]>();
    }

    // Root configuration object containing a collection of kernels
    public class KernelConfig
    {
        public List<KernelDefinition> Kernels { get; set; } = new List<KernelDefinition>();
    }

    class Program
    {
        static void Main()
        {
            // Hard‑coded output path for the JSON configuration file
            string outputPath = "config/kernelConfig.json";

            try
            {
                // Ensure the output directory exists (unconditional call as required)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

                // Build the configuration with custom kernels
                var config = new KernelConfig();

                // Example: 3x3 emboss kernel
                config.Kernels.Add(new KernelDefinition
                {
                    Name = "CustomEmboss3x3",
                    Matrix = new double[][]
                    {
                        new double[] { -2, -1, 0 },
                        new double[] { -1,  1, 1 },
                        new double[] {  0,  1, 2 }
                    }
                });

                // Example: 5x5 sharpen kernel
                config.Kernels.Add(new KernelDefinition
                {
                    Name = "CustomSharpen5x5",
                    Matrix = new double[][]
                    {
                        new double[] {  0, -1, -1, -1,  0 },
                        new double[] { -1,  2, -4,  2, -1 },
                        new double[] { -1, -4, 13, -4, -1 },
                        new double[] { -1,  2, -4,  2, -1 },
                        new double[] {  0, -1, -1, -1,  0 }
                    }
                });

                // Serialize the configuration to JSON with indentation for readability
                var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(config, jsonOptions);

                // Write the JSON content to the file
                File.WriteAllText(outputPath, json);
            }
            catch (Exception ex)
            {
                // Report any runtime errors without crashing
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer wants to apply custom emboss or sharpen effects to JPEG or PNG images at runtime without recompiling the application, they can load the kernel matrices from the generated JSON file using Aspose.Imaging for .NET.
 * 2. When an image‑processing pipeline must support user‑defined convolution filters that can be updated by non‑technical staff, the JSON configuration lets the C# code read new kernel definitions without code changes.
 * 3. When a batch‑processing service needs to apply different convolution kernels to TIFF files based on external configuration, the generated kernelConfig.json provides a centralized, version‑controlled source for those matrices.
 * 4. When a desktop application requires dynamic selection of edge‑detection or blur kernels for BMP images based on user preferences, loading the kernels from the JSON file enables real‑time switching.
 * 5. When a cloud‑based image‑enhancement API must expose customizable filter options to clients, developers can store the custom kernel definitions in the JSON file and have Aspose.Imaging apply them during request handling.
 */