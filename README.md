![image](https://user-images.githubusercontent.com/32739337/100557612-b5aabb80-3280-11eb-8201-1706ba5f9f4d.png)
# Endless Procedural Ecosystem
This Project is an endlessly generating procedural landscape. 
Biomes are currently in the works. 

## The Terrain Generation
There is a Chunk of terrain that is created using Unity's Perlin noise algorithm to generate random values between 0-1, then a height curve is applied to create flat water and steep hills. 

To apply the texture to each chunk, it uses a shader that determins what texture should be applied based on the world position of each pixel.

The picture shows many chunks being placed in the players rendering distance, as the player traverses towards the edge of the generated chunks, the ones furthest away from the player are hidden and new ones are generated or shown infront of the player to have a seeming endless landscape.

![image](https://user-images.githubusercontent.com/32739337/99461091-789d0b80-2907-11eb-91eb-21bd00bf0ecd.png)

## Endless Terrain Generation
![endlessDemo](https://user-images.githubusercontent.com/32739337/102147806-b8d9a600-3e41-11eb-849c-aa15d9fa2c8d.gif)
The endless generation is done by creating chunks around the player, when the player moves a certain distance, the most distant chunks are unloaded and new ones closer to the player are created or re-enabled

## Level of Detail over Distance
Depending on the distance of each chunk from the player, the number of vertices can be lowered for better performance. Mesh near the player is created with a higher amount of vertices compared to mesh further away from players.  

With three different Level of Detail settings, you can see the visible difference in the Triangle count, this allows for a boost in performance with an almost unnoticable change.
![image](https://user-images.githubusercontent.com/32739337/100610136-88442900-32e5-11eb-80d1-a1c360a25790.png)

This image has 2 different level of detail meshs pictured, the border of the chunk with the lower level of detail. 
![image](https://user-images.githubusercontent.com/32739337/100557763-8183ca80-3281-11eb-9bc4-1f8386a82349.png)

## Seamless Chunk Borders
 This caused issues with the border each chunk not properly aligning with a chunk with less verticies. It wasn't a big issue but sometimes in the distance it wouldn't look smooth and would break immersion. The solution to this was to create a high detail border so that each chunk, no matter the detail was using the same border quality, allowing for a smooth and seamless terrain.       
![image](https://user-images.githubusercontent.com/32739337/100557982-aaf12600-3282-11eb-83ec-dc7047e93cad.png)

## FlatShading
I have also implemented FlatShading, giving a lower poly look. 
![image](https://user-images.githubusercontent.com/32739337/100622232-ffce8400-32f6-11eb-995c-4b10dde1daac.png)


## Textures
Textures are applied using a pixel shader, it gets the heigh of the pixel, and based off of that, it applies the texture. I learned about triplanar mapping to smoothly apply textures over the terrain. 
### Without Triplanar
![image](https://user-images.githubusercontent.com/32739337/102144728-60ec7080-3e3c-11eb-8589-011861e3d3b1.png)

### With Triplanar
![image](https://user-images.githubusercontent.com/32739337/102144377-c2600f80-3e3b-11eb-91f8-7f43d3fdefb5.png)

### I also Used Texture Blending near the edges to jagged changes between textures. 

### This is without the blending.
![image](https://user-images.githubusercontent.com/32739337/102143911-07377680-3e3b-11eb-997a-40b25f46ccf6.png)

### With Texture Blending
![image](https://user-images.githubusercontent.com/32739337/102144266-93e23480-3e3b-11eb-9850-6aa5ca965895.png)
