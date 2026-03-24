using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.PathResources;
using Aspose.Imaging.FileFormats.Core.VectorPaths;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.tif";
        string outputPath = "output.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the TIFF image
        using (var image = (TiffImage)Image.Load(inputPath))
        {
            // Define coordinates for the clipping path (normalized 0..1)
            float[] coordinates = { 0.2f, 0.2f, 0.8f, 0.2f, 0.8f, 0.8f, 0.2f, 0.8f };

            // Create Bezier knot records from coordinates
            var records = new List<VectorPathRecord>();
            for (int i = 0; i < coordinates.Length; i += 2)
            {
                var pt = new PointF(coordinates[i], coordinates[i + 1]);
                var bezier = new BezierKnotRecord { PathPoints = new[] { pt, pt, pt } };
                records.Add(bezier);
            }

            // Insert LengthRecord as the first record (required by Photoshop spec)
            records.Insert(0, new LengthRecord
            {
                IsOpen = false,
                RecordCount = (ushort)records.Count
            });

            // Create the PathResource with the records
            var pathResource = new PathResource
            {
                BlockId = 2000,                     // Block ID per Photoshop spec
                Name = "My Clipping Path",
                Records = records
            };

            // Assign the new clipping path to the active frame
            image.ActiveFrame.PathResources = new List<PathResource> { pathResource };

            // Save the modified TIFF image
            image.Save(outputPath);
        }
    }
}