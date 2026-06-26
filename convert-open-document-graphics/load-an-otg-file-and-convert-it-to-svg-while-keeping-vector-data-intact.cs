using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.otg";
            string outputPath = "Output\\sample.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                OtgRasterizationOptions otgOptions = new OtgRasterizationOptions();
                otgOptions.PageSize = image.Size;

                SvgOptions svgOptions = new SvgOptions();
                svgOptions.VectorRasterizationOptions = otgOptions;

                image.Save(outputPath, svgOptions);
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
 * 1. When a developer needs to import an OTG (OpenType Graphics) font glyph file into a web application and serve it as scalable SVG graphics without losing vector quality.
 * 2. When a C# backend service must batch‑convert legacy OTG vector assets to SVG for responsive UI design in cross‑platform mobile apps.
 * 3. When an automated build pipeline has to transform OTG icons into SVG files for inclusion in a vector‑based UI component library using Aspose.Imaging.
 * 4. When a document‑generation tool requires preserving vector paths while converting OTG diagrams to SVG for high‑resolution printing.
 * 5. When a cloud‑based image processing API must accept OTG uploads and return SVG output to enable client‑side manipulation in JavaScript editors.
 */