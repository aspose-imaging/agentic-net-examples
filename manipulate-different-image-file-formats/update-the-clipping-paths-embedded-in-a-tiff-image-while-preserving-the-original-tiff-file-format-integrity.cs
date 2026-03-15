using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.PathResources;

class UpdateTiffClippingPaths
{
    static void Main()
    {
        // Load the existing TIFF image
        using (var image = (TiffImage)Image.Load("input.tif"))
        {
            // Get current clipping paths
            List<PathResource> currentPaths = image.ActiveFrame.PathResources;

            // Keep only the first existing path (if any)
            List<PathResource> updatedPaths = currentPaths.Take(1).ToList();

            // Create a new clipping path and add it to the collection
            var newPath = new PathResource
            {
                BlockId = 2000,                     // Photoshop block identifier
                Name = "Updated Path",               // Path name
                Records = CreateRectanglePath()      // Path records defining a rectangle
            };
            updatedPaths.Add(newPath);

            // Assign the modified path collection back to the active frame
            image.ActiveFrame.PathResources = updatedPaths;

            // Save the image – no options are required to preserve the original TIFF format
            image.Save("output.tif");
        }
    }

    // Helper: creates a simple rectangular clipping path using Photoshop path records
    private static List<VectorPathRecord> CreateRectanglePath()
    {
        var records = new List<VectorPathRecord>();

        // LengthRecord – closed path with 5 records (1 length + 4 corners)
        records.Add(new LengthRecord
        {
            IsOpen = false,
            RecordCount = 5
        });

        // Define rectangle corners (normalized coordinates 0‑1)
        PointF[] corners =
        {
            new PointF(0.1f, 0.1f),
            new PointF(0.9f, 0.1f),
            new PointF(0.9f, 0.9f),
            new PointF(0.1f, 0.9f)
        };

        // Each corner is a BezierKnotRecord with identical control points (straight lines)
        foreach (var pt in corners)
        {
            records.Add(new BezierKnotRecord
            {
                PathPoints = new[] { pt, pt, pt }
            });
        }

        return records;
    }
}