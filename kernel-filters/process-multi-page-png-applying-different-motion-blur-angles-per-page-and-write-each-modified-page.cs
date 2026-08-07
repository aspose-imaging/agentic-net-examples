using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.apng";
        string outputDir = "output";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDir);

            using (Image image = Image.Load(inputPath))
            {
                if (image is IMultipageImage multipageImage)
                {
                    int pageCount = multipageImage.PageCount;
                    double[] angles = new double[] { 0, 45, 90, 135, 180, 225, 270, 315 };

                    for (int i = 0; i < pageCount; i++)
                    {
                        using (RasterImage page = (RasterImage)multipageImage.Pages[i])
                        {
                            double angle = angles[i % angles.Length];
                            var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.MotionWienerFilterOptions(10, 1.0, angle);
                            page.Filter(page.Bounds, filterOptions);

                            string outputPath = Path.Combine(outputDir, $"page_{i}.png");
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                            page.Save(outputPath, new PngOptions());
                        }
                    }
                }
                else
                {
                    Console.Error.WriteLine("The loaded image is not a multipage image.");
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
 * 1. When building an animated PNG (APNG) slideshow, a developer can use this code to apply a unique motion‑blur angle to each frame, creating a dynamic transition effect for web or desktop UI animations.
 * 2. When preparing sprite sheets for a 2‑D game, the code lets a developer process each page of a multi‑page PNG and add directional motion blur, giving characters a sense of movement direction without manual editing.
 * 3. When converting scanned multi‑page PNG documents into stylized images, a developer can apply varying blur angles per page to highlight page order or emphasize visual hierarchy in reports or presentations.
 * 4. When generating a series of promotional banners for a website carousel, the code enables a developer to automatically add different motion‑blur angles to each PNG page, producing eye‑catching motion effects without creating separate assets.
 * 5. When visualizing time‑lapse or scientific data stored as a multi‑page PNG, a developer can use this routine to apply distinct motion‑blur angles per frame, helping viewers perceive directional changes across the dataset.
 */