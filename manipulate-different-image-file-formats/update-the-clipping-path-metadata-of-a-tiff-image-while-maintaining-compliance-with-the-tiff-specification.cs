using System;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Expect input and output file paths as arguments
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: <program> <input.tif> <output.tif>");
            return;
        }

        string inputPath = args[0];
        string outputPath = args[1];

        // Load the TIFF image
        using (TiffImage image = (TiffImage)Image.Load(inputPath))
        {
            // Retrieve current clipping path resources
            var currentPaths = image.ActiveFrame.PathResources;

            if (currentPaths != null && currentPaths.Count > 0)
            {
                // Update the name of the first clipping path
                currentPaths[0].Name = "Updated Clipping Path";
                // Assign the modified list back
                image.ActiveFrame.PathResources = currentPaths;
            }
            else
            {
                // No existing paths – create a new clipping path resource
                image.ActiveFrame.PathResources = new List<Aspose.Imaging.FileFormats.Tiff.PathResources.PathResource>
                {
                    new Aspose.Imaging.FileFormats.Tiff.PathResources.PathResource
                    {
                        BlockId = 2000,
                        Name = "Updated Clipping Path",
                        Records = new List<Aspose.Imaging.FileFormats.Tiff.PathResources.VectorPathRecord>()
                    }
                };
            }

            // Save the updated TIFF image
            image.Save(outputPath);
        }
    }
}