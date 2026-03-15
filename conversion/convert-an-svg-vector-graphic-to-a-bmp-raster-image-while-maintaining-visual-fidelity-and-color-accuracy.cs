using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

namespace SvgToBmpConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            // Expect input SVG path as first argument and output BMP path as second argument.
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: SvgToBmpConversion <input.svg> <output.bmp>");
                return;
            }

            string inputPath = args[0];
            string outputPath = args[1];

            // Load the SVG image using Aspose.Imaging.Image.Load.
            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization options to preserve the original size.
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Set BMP save options and attach the rasterization options.
                BmpOptions bmpOptions = new BmpOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save the rasterized image as BMP.
                image.Save(outputPath, bmpOptions);
            }
        }
    }
}