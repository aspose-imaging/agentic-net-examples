// HOW-TO: Crop JPEG Images Using CSV Coordinates with Aspose.Imaging in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;

namespace ImageCropper
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Hardcoded paths
                string csvPath = "input.csv";
                string inputFolder = "input_images";
                string outputFolder = "output_images";

                // Verify CSV file exists
                if (!File.Exists(csvPath))
                {
                    Console.Error.WriteLine($"File not found: {csvPath}");
                    return;
                }

                // Read all lines from CSV
                string[] lines = File.ReadAllLines(csvPath);
                foreach (string line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    // Expected format: filename,x,y,width,height
                    string[] parts = line.Split(',');
                    if (parts.Length < 5)
                        continue; // skip malformed lines

                    string fileName = parts[0].Trim();
                    if (!int.TryParse(parts[1].Trim(), out int x)) continue;
                    if (!int.TryParse(parts[2].Trim(), out int y)) continue;
                    if (!int.TryParse(parts[3].Trim(), out int width)) continue;
                    if (!int.TryParse(parts[4].Trim(), out int height)) continue;

                    string inputPath = Path.Combine(inputFolder, fileName);
                    string outputPath = Path.Combine(outputFolder, fileName);

                    // Input file existence check
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        continue;
                    }

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Load, crop, and save the image
                    using (RasterImage rasterImage = (RasterImage)Image.Load(inputPath))
                    {
                        if (!rasterImage.IsCached)
                        {
                            rasterImage.CacheData();
                        }

                        Aspose.Imaging.Rectangle rectangle = new Aspose.Imaging.Rectangle(x, y, width, height);
                        rasterImage.Crop(rectangle);
                        rasterImage.Save(outputPath);
                    }
                }
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
 * 1. When you need to batch‑crop a large set of JPEG photos based on rectangle data stored in a CSV file, this code reads the coordinates and creates cropped versions automatically.
 * 2. When an e‑commerce platform must generate product thumbnail images from original JPEGs using pre‑defined crop areas listed in a spreadsheet, the example shows how to do it in C#.
 * 3. When a digital asset management system has to extract specific regions from scanned JPEG documents according to coordinates supplied by a metadata CSV, the code performs the cropping and saves the results.
 * 4. When a marketing team provides a CSV of focus‑area dimensions for campaign images, developers can use this snippet to programmatically crop each JPEG to the required size before uploading.
 * 5. When you want to automate the preparation of profile picture crops from user‑uploaded JPEGs using a CSV of x, y, width, and height values, this solution processes the files and writes the cropped images to an output folder.
 */
