// HOW-TO: Apply JSON Defined Convolution Kernel To Batch SVG To PNG In C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-09
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string configPath = "config.json";
            string inputFolder = "input_svgs";
            string outputFolder = "output_pngs";

            if (!File.Exists(configPath))
            {
                Console.Error.WriteLine($"File not found: {configPath}");
                return;
            }

            Directory.CreateDirectory(outputFolder);

            string json = File.ReadAllText(configPath);
            List<double> numbers = new List<double>();
            string currentNumber = "";
            bool inNumber = false;
            foreach (char c in json)
            {
                if (char.IsDigit(c) || c == '-' || c == '.')
                {
                    currentNumber += c;
                    inNumber = true;
                }
                else
                {
                    if (inNumber)
                    {
                        if (double.TryParse(currentNumber, out double val))
                            numbers.Add(val);
                        currentNumber = "";
                        inNumber = false;
                    }
                }
            }
            if (inNumber && double.TryParse(currentNumber, out double lastVal))
                numbers.Add(lastVal);

            if (numbers.Count == 0)
            {
                Console.Error.WriteLine("No kernel data found in config.");
                return;
            }

            int kernelSize = (int)Math.Sqrt(numbers.Count);
            if (kernelSize * kernelSize != numbers.Count || kernelSize % 2 == 0)
            {
                Console.Error.WriteLine("Kernel must be a square matrix with odd dimensions.");
                return;
            }

            double[,] kernel = new double[kernelSize, kernelSize];
            for (int i = 0; i < numbers.Count; i++)
            {
                int row = i / kernelSize;
                int col = i % kernelSize;
                kernel[row, col] = numbers[i];
            }

            string[] svgFiles = Directory.GetFiles(inputFolder, "*.svg");
            foreach (string inputPath in svgFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(inputPath) + ".png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image img = Image.Load(inputPath))
                {
                    SvgImage svg = (SvgImage)img;

                    using (MemoryStream ms = new MemoryStream())
                    {
                        var pngOptions = new PngOptions
                        {
                            VectorRasterizationOptions = new SvgRasterizationOptions
                            {
                                PageWidth = svg.Width,
                                PageHeight = svg.Height
                            }
                        };
                        svg.Save(ms, pngOptions);
                        ms.Position = 0;

                        using (RasterImage raster = (RasterImage)Image.Load(ms))
                        {
                            int width = raster.Width;
                            int height = raster.Height;
                            int[] originalPixels = raster.LoadArgb32Pixels(raster.Bounds);
                            int[] newPixels = new int[originalPixels.Length];
                            int kHalf = kernelSize / 2;

                            Array.Copy(originalPixels, newPixels, originalPixels.Length);

                            for (int y = kHalf; y < height - kHalf; y++)
                            {
                                for (int x = kHalf; x < width - kHalf; x++)
                                {
                                    double sumA = 0, sumR = 0, sumG = 0, sumB = 0;
                                    for (int ky = 0; ky < kernelSize; ky++)
                                    {
                                        for (int kx = 0; kx < kernelSize; kx++)
                                        {
                                            int srcX = x + kx - kHalf;
                                            int srcY = y + ky - kHalf;
                                            int pixel = originalPixels[srcY * width + srcX];
                                            double k = kernel[ky, kx];

                                            sumA += ((pixel >> 24) & 0xFF) * k;
                                            sumR += ((pixel >> 16) & 0xFF) * k;
                                            sumG += ((pixel >> 8) & 0xFF) * k;
                                            sumB += (pixel & 0xFF) * k;
                                        }
                                    }

                                    int a = Math.Clamp((int)Math.Round(sumA), 0, 255);
                                    int r = Math.Clamp((int)Math.Round(sumR), 0, 255);
                                    int g = Math.Clamp((int)Math.Round(sumG), 0, 255);
                                    int b = Math.Clamp((int)Math.Round(sumB), 0, 255);
                                    newPixels[y * width + x] = (a << 24) | (r << 16) | (g << 8) | b;
                                }
                            }

                            raster.SaveArgb32Pixels(raster.Bounds, newPixels);
                            raster.Save(outputPath, new PngOptions());
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to programmatically sharpen or blur a collection of SVG graphics using a custom filter defined in a JSON file before converting them to PNG.
 * 2. When you want to automate image preprocessing for a web app by reading a kernel matrix from configuration and applying it to every SVG in a folder.
 * 3. When you must ensure consistent image effects across dozens of vector assets by loading the same convolution parameters from JSON and rendering the results as raster PNGs.
 * 4. When you are building a CI pipeline that validates visual quality by applying a custom kernel to SVGs and comparing the generated PNG outputs.
 * 5. When you need to let non‑technical users edit a JSON file to change the filter strength and have your C# code automatically re‑process all SVG files with the new kernel.
 */
