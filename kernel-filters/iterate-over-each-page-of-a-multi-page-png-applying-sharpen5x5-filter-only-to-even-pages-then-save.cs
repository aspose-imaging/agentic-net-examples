using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
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

        try
        {
            // Load the multi‑page PNG (APNG) image
            using (Image img = Image.Load(inputPath))
            {
                // Cast to ApngImage to access pages
                if (img is ApngImage apngImage && apngImage.Pages != null)
                {
                    // Iterate over each page
                    for (int i = 0; i < apngImage.Pages.Length; i++)
                    {
                        // Even page numbers (2,4,…) – using 1‑based indexing
                        if ((i + 1) % 2 == 0)
                        {
                            // Each page is a RasterImage
                            if (apngImage.Pages[i] is RasterImage rasterPage)
                            {
                                // Apply Sharpen filter with a 5×5 kernel
                                rasterPage.Filter(rasterPage.Bounds, new SharpenFilterOptions(5, 4.0));
                            }
                        }
                    }
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the modified image
                img.Save(outputPath);
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
 * 1. When creating an animated product showcase where every second frame needs enhanced edge definition, a developer can use this code to sharpen only the even pages of an APNG before publishing.
 * 2. When processing a multi‑page medical scan stored as an APNG and the analyst wants to highlight details on alternate slices, the code can apply a 5×5 sharpen filter to those even‑indexed pages.
 * 3. When generating a slideshow of UI mockups in an APNG and the designer wants the transition frames (every second page) to appear crisper, the developer can iterate and sharpen those pages with this snippet.
 * 4. When automating quality‑control for a batch of animated icons and the requirement is to boost contrast on even frames to meet branding guidelines, this C# example provides the exact steps.
 * 5. When building a game asset pipeline that stores character animation frames in an APNG and the developer needs to sharpen only the keyframes located on even pages, the code demonstrates how to filter and save the result.
 */