using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace ImageConversionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Folder containing source images (any raster or vector format supported by Aspose.Imaging)
            string sourceFolder = @"C:\Images\Input";

            // Destination folder for the converted SVG files
            string destinationFolder = @"C:\Images\Output";

            // Ensure the output directory exists
            Directory.CreateDirectory(destinationFolder);

            // Process each file in the source folder
            foreach (string inputFile in Directory.GetFiles(sourceFolder))
            {
                // Build the output file path with .svg extension
                string outputFile = Path.Combine(
                    destinationFolder,
                    Path.GetFileNameWithoutExtension(inputFile) + ".svg");

                ConvertToSvg(inputFile, outputFile);
                Console.WriteLine($"Converted: {inputFile} -> {outputFile}");
            }
        }

        /// <summary>
        /// Loads an image using Aspose.Imaging's Image.Load method and saves it as SVG.
        /// The method preserves visual fidelity by using the original image size for rasterization
        /// and retains metadata automatically during the save operation.
        /// </summary>
        /// <param name="inputPath">Full path to the source image.</param>
        /// <param name="outputPath">Full path where the SVG will be saved.</param>
        private static void ConvertToSvg(string inputPath, string outputPath)
        {
            // Load the image from the file system (lifecycle rule: load)
            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization options: use the original image size as the page size
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Create SVG save options and attach the rasterization settings
                SvgOptions svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = rasterOptions,
                    // Preserve metadata (metadata is retained by default; no extra code needed)
                    // If compression is desired, set Compress = true; here we keep it uncompressed.
                };

                // Save the image as SVG (lifecycle rule: save)
                image.Save(outputPath, svgOptions);
            }
        }
    }
}