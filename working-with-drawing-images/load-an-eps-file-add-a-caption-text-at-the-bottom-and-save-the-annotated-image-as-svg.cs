using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.eps";
            string outputPath = "output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (Image epsImage = Image.Load(inputPath))
            {
                // Cast to EpsImage for clarity (optional)
                EpsImage eps = epsImage as EpsImage;
                if (eps == null)
                {
                    Console.Error.WriteLine("Failed to load EPS image.");
                    return;
                }

                // Create graphics for drawing on the EPS image
                Graphics graphics = new Graphics(eps);

                // Prepare font and brush for caption
                Font font = new Font("Arial", 24, FontStyle.Regular);
                using (SolidBrush brush = new SolidBrush(Color.Black))
                {
                    // Position caption near the bottom-left corner
                    int captionX = 10;
                    int captionY = eps.Height - 30;
                    graphics.DrawString("Caption Text", font, brush, new Point(captionX, captionY));
                }

                // Save the annotated image as SVG
                SvgOptions svgOptions = new SvgOptions();
                eps.Save(outputPath, svgOptions);
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
 * 1. When a developer needs to convert a vector EPS illustration into a web‑friendly SVG while adding a descriptive caption at the bottom of the image.
 * 2. When an automated report generator must annotate printed EPS charts with titles or notes before embedding them in an SVG dashboard.
 * 3. When a branding workflow requires adding a trademark or copyright notice to existing EPS logos and exporting the result as scalable SVG for responsive design.
 * 4. When a batch processing script has to read EPS files, overlay product identifiers using C# graphics drawing, and save the annotated graphics as SVG for downstream publishing.
 * 5. When a document conversion tool needs to preserve vector quality of EPS artwork, insert explanatory text, and output the final file in SVG format for compatibility with modern browsers.
 */