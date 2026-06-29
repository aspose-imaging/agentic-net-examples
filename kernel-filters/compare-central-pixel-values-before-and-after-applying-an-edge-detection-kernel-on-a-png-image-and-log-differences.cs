using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.png";
            string outputPath = @"C:\Images\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (PngImage pngImage = new PngImage(inputPath))
            {
                int width = pngImage.Width;
                int height = pngImage.Height;

                // Determine central pixel coordinates
                int cx = width / 2;
                int cy = height / 2;

                // Get ARGB value before processing
                int beforeArgb = pngImage.GetArgb32Pixel(cx, cy);

                // Helper to extract grayscale intensity from ARGB
                int GetIntensity(int argb)
                {
                    int r = (argb >> 16) & 0xFF;
                    int g = (argb >> 8) & 0xFF;
                    int b = argb & 0xFF;
                    return (r + g + b) / 3;
                }

                // Edge‑detection kernel (Laplacian)
                int[,] kernel = new int[,]
                {
                    { 0, -1,  0 },
                    { -1, 4, -1 },
                    { 0, -1,  0 }
                };

                // Apply kernel to the central pixel (using its 3×3 neighbourhood)
                int newIntensity = 0;
                for (int dy = -1; dy <= 1; dy++)
                {
                    for (int dx = -1; dx <= 1; dx++)
                    {
                        int nx = cx + dx;
                        int ny = cy + dy;

                        // Clamp coordinates to image bounds
                        nx = Math.Max(0, Math.Min(width - 1, nx));
                        ny = Math.Max(0, Math.Min(height - 1, ny));

                        int neighborArgb = pngImage.GetArgb32Pixel(nx, ny);
                        int neighborIntensity = GetIntensity(neighborArgb);
                        newIntensity += neighborIntensity * kernel[dy + 1, dx + 1];
                    }
                }

                // Clamp result to valid byte range
                newIntensity = Math.Max(0, Math.Min(255, newIntensity));

                // Preserve original alpha channel
                int alpha = (beforeArgb >> 24) & 0xFF;
                int afterArgb = (alpha << 24) | (newIntensity << 16) | (newIntensity << 8) | newIntensity;

                // Set the new ARGB value for the central pixel
                pngImage.SetArgb32Pixel(cx, cy, afterArgb);

                // Save the modified image
                pngImage.Save(outputPath);

                // Log the comparison
                Console.WriteLine($"Central pixel before: 0x{beforeArgb:X8}");
                Console.WriteLine($"Central pixel after : 0x{afterArgb:X8}");
                Console.WriteLine($"Difference (absolute): {Math.Abs(beforeArgb - afterArgb)}");
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
 * 1. When a developer needs to verify that an edge‑detection filter (e.g., Laplacian kernel) correctly highlights boundaries in a PNG image by checking the change in the central pixel’s intensity.
 * 2. When building an automated quality‑control pipeline that logs differences in central pixel values before and after applying a convolution kernel to detect processing anomalies in medical imaging PNG files.
 * 3. When creating a diagnostic tool for a C# desktop application that compares ARGB values of the central pixel in a PNG screenshot to ensure that image‑processing routines such as sharpening or edge detection are functioning as expected.
 * 4. When implementing a unit test for a graphics library that confirms the Laplacian edge‑detection kernel modifies the grayscale intensity of the central pixel in a PNG image as intended.
 * 5. When developing a batch‑processing script that processes PNG assets for a game and records any significant central‑pixel intensity changes after applying edge detection to identify images that may need manual review.
 */