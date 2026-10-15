// HOW-TO: Automatically Remove Solid Color Borders from BMP Image in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.bmp";
        string outputPath = "output\\output.bmp";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.RasterImage image = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
            {
                Aspose.Imaging.Color borderColor = image.GetPixel(0, 0);

                int left = 0;
                int right = image.Width - 1;
                int top = 0;
                int bottom = image.Height - 1;

                while (left <= right)
                {
                    bool columnSame = true;
                    for (int y = 0; y < image.Height; y++)
                    {
                        if (image.GetPixel(left, y) != borderColor)
                        {
                            columnSame = false;
                            break;
                        }
                    }
                    if (columnSame) left++;
                    else break;
                }

                while (right >= left)
                {
                    bool columnSame = true;
                    for (int y = 0; y < image.Height; y++)
                    {
                        if (image.GetPixel(right, y) != borderColor)
                        {
                            columnSame = false;
                            break;
                        }
                    }
                    if (columnSame) right--;
                    else break;
                }

                while (top <= bottom)
                {
                    bool rowSame = true;
                    for (int x = 0; x < image.Width; x++)
                    {
                        if (image.GetPixel(x, top) != borderColor)
                        {
                            rowSame = false;
                            break;
                        }
                    }
                    if (rowSame) top++;
                    else break;
                }

                while (bottom >= top)
                {
                    bool rowSame = true;
                    for (int x = 0; x < image.Width; x++)
                    {
                        if (image.GetPixel(x, bottom) != borderColor)
                        {
                            rowSame = false;
                            break;
                        }
                    }
                    if (rowSame) bottom--;
                    else break;
                }

                int cropWidth = right - left + 1;
                int cropHeight = bottom - top + 1;

                if (cropWidth > 0 && cropHeight > 0 && (left > 0 || top > 0 || cropWidth != image.Width || cropHeight != image.Height))
                {
                    Aspose.Imaging.Rectangle rect = new Aspose.Imaging.Rectangle(left, top, cropWidth, cropHeight);
                    image.Crop(rect);
                }

                var saveOptions = new BmpOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                image.Save(outputPath, saveOptions);
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
 * 1. When preparing scanned documents for OCR, you may need to strip uniform color margins from BMP files before text extraction.
 * 2. When generating thumbnails for a photo gallery, removing solid borders from BMP images ensures consistent sizing without extra padding.
 * 3. When converting legacy BMP assets to modern formats, eliminating unwanted frame colors prevents artifacts in the final PNG or JPEG.
 * 4. When performing batch image analysis, cleaning solid color edges from BMP files improves accuracy of shape detection algorithms.
 * 5. When integrating BMP images into a UI layout, automatically cropping uniform borders simplifies alignment and reduces layout calculations.
 */
