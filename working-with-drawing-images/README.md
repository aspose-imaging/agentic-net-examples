# Draw on Image C# with Aspose.Imaging

Use Aspose.Imaging for .NET to draw on images directly from C#. The examples below demonstrate graphics drawing in .NET, covering basic shapes, lines, and background fills with the **image drawing Aspose** API.

## What's in This Category
- Create a BMP canvas and set a solid background color.  
- Draw straight lines with custom colors and thickness.  
- Render rectangles (filled or outlined) on an image.  
- Work with `MemoryStream` to generate images in memory.  
- Save the resulting image to file or stream.

## Quick Start
The most common scenario is creating a bitmap, clearing its background, drawing a line, and saving the result:

```csharp
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Drawing;

// Create a 500×300 BMP canvas
using var image = new Image<BmpOptions>(new BmpOptions(), 500, 300);
var graphics = new Graphics(image);

// Fill background with white
graphics.Clear(Color.White);

// Draw a blue line from (50,50) to (450,250)
graphics.DrawLine(new Pen(Color.Blue, 3), 50, 50, 450, 250);

// Save to file
image.Save("output.bmp");
```

## All Examples

| Example | Description |
|---|---|
| [create-a-200-200-bmp-image-clear-background-to-red-and-save-to-file.cs](./create-a-200-200-bmp-image-clear-background-to-red-and-save-to-file.cs) | Create a 200 × 200 BMP image, clear background to red, and save to file. |
| [generate-a-500-300-bmp-canvas-and-draw-a-blue-line-from-50-50-to-450-250.cs](./generate-a-500-300-bmp-canvas-and-draw-a-blue-line-from-50-50-to-450-250.cs) | Generate a 500 × 300 BMP canvas and draw a blue line from (50,50) to (450,250). |
| [initialize-a-memorystream-create-a-bmp-image-draw-a-green-rectangle-and-write-to-stream.cs](./initialize-a-memorystream-create-a-bmp-image-draw-a-green-rectangle-and-write-to-stream.cs) | Initialize a `MemoryStream`, create a BMP image, draw a green rectangle, and write the image to the stream. |

## Requirements
- **Aspose.Imaging** NuGet package (latest version)  
- **.NET 9** or later  

[← Back to Root README](../README.md)