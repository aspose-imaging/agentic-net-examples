// HOW-TO: Validate Custom Convolution Kernel Sum Equals One in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "kernel.txt";
            string outputPath = "result.txt";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            var lines = File.ReadAllLines(inputPath);
            List<double> values = new List<double>();

            foreach (var line in lines)
            {
                var parts = line.Split(new[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var part in parts)
                {
                    if (double.TryParse(part, out double val))
                    {
                        values.Add(val);
                    }
                }
            }

            double sum = values.Sum();
            bool isValid = Math.Abs(sum - 1.0) < 1e-6;

            File.WriteAllText(outputPath, isValid ? "Valid" : "Invalid");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When creating a custom sharpening filter for JPEG images, you can use this code to ensure the kernel coefficients sum to one so the overall brightness remains unchanged.
 * 2. When loading a user‑defined Gaussian blur kernel from a text file in a C# image‑processing app, the program verifies the kernel is normalized before applying it to PNG files.
 * 3. When building a real‑time video processing pipeline that accepts external kernel files, this validation step prevents unintended brightness shifts in each frame.
 * 4. When testing different edge‑detection kernels stored in CSV format, the script confirms they are properly normalized before they are used with Aspose.Imaging filters.
 * 5. When automating batch conversion of TIFF images with custom convolution kernels, the code checks each kernel file for a sum of one to maintain consistent image exposure.
 */
