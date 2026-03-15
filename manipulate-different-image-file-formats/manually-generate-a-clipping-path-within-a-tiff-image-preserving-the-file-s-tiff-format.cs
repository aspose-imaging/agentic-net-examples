using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Create TIFF options for a new image
        TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
        // Create a new TIFF image (800x600)
        using (TiffImage image = (TiffImage)Image.Create(tiffOptions, 800, 600))
        {
            // Coordinates for a simple rectangular clipping path (normalized 0..1)
            float[] coords = new float[] { 0.2f, 0.2f, 0.8f, 0.2f, 0.8f, 0.8f, 0.2f, 0.8f };

            // List of vector path records (Bezier knots)
            List<Aspose.Imaging.FileFormats.Tiff.PathResources.VectorPathRecord> records =
                new List<Aspose.Imaging.FileFormats.Tiff.PathResources.VectorPathRecord>();

            // Create BezierKnotRecord for each coordinate pair
            for (int i = 0; i < coords.Length; i += 2)
            {
                Aspose.Imaging.PointF pt = new Aspose.Imaging.PointF(coords[i], coords[i + 1]);
                var bezier = new Aspose.Imaging.FileFormats.Tiff.PathResources.BezierKnotRecord
                {
                    PathPoints = new[] { pt, pt, pt }
                };
                records.Add(bezier);
            }

            // LengthRecord must be the first record
            var lengthRecord = new Aspose.Imaging.FileFormats.Tiff.PathResources.LengthRecord
            {
                IsOpen = false,
                RecordCount = (ushort)records.Count
            };
            records.Insert(0, lengthRecord);

            // Create the PathResource containing the records
            var pathResource = new Aspose.Imaging.FileFormats.Tiff.PathResources.PathResource
            {
                BlockId = 2000,
                Name = "My Clipping Path",
                Records = records
            };

            // Assign the clipping path to the active frame
            image.ActiveFrame.PathResources = new List<Aspose.Imaging.FileFormats.Tiff.PathResources.PathResource> { pathResource };

            // Save the TIFF image preserving the format
            image.Save("ImageWithClippingPath.tif");
        }
    }
}