using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.Tiff.PathResources;
using Aspose.Imaging.FileFormats.Core.VectorPaths;

class Program
{
    static void Main(string[] args)
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

        // Load the existing TIFF image
        using (TiffImage image = (TiffImage)Image.Load(inputPath))
        {
            // Coordinates for the clipping path (normalized 0..1)
            float[] coordinates = new float[] { 0.2f, 0.2f, 0.8f, 0.2f, 0.8f, 0.8f, 0.2f, 0.8f };

            // Build the list of VectorPathRecord objects
            var records = new List<VectorPathRecord>();

            for (int i = 0; i < coordinates.Length; i += 2)
            {
                float x = coordinates[i];
                float y = coordinates[i + 1];
                var point = new PointF(x, y);

                var bezier = new BezierKnotRecord
                {
                    PathPoints = new[] { point, point, point }
                };
                records.Add(bezier);
            }

            // Insert the required LengthRecord at the beginning
            var lengthRecord = new LengthRecord
            {
                IsOpen = false,
                RecordCount = (ushort)records.Count
            };
            records.Insert(0, lengthRecord);

            // Create the PathResource and assign it to the active frame
            var pathResource = new PathResource
            {
                BlockId = 2000,                     // Photoshop specification block ID
                Name = "My Clipping Path",           // Path name
                Records = records
            };

            image.ActiveFrame.PathResources = new List<PathResource> { pathResource };

            // Save the modified TIFF image
            image.Save(outputPath);
        }
    }
}