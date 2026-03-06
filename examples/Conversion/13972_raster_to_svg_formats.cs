using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats;

class Program
{
    static void Main()
    {
        // Retrieve all formats that Aspose.Imaging can load
        FileFormat registeredLoaders = ImageLoadersRegistry.RegisteredFormats;

        // Enumerate each defined format in the FileFormat enum
        foreach (FileFormat format in Enum.GetValues(typeof(FileFormat)))
        {
            // Skip unknown and vector formats that are not raster sources
            if (format == FileFormat.Unknown || format == FileFormat.Svg || format == FileFormat.Svgz)
                continue;

            // If the format flag is present in the registered loaders, it can be used as input
            if ((registeredLoaders & format) != 0)
            {
                // This raster format can be loaded and then saved as SVG using SvgOptions
                Console.WriteLine(format);
            }
        }
    }
}