![image](https://user-images.githubusercontent.com/32739337/100557612-b5aabb80-3280-11eb-8201-1706ba5f9f4d.png)
# Procedural Ecosystem
This Project is an endlessly generating procedural landscape with mountains, trees, grass, water and animals. 

## The Terrain Generation
There is a Chunk of terrain that is created using Unity's Perlin noise algorithm to generate random values between 0-1, then a height curve is applied to create flat water and steep hills. 

To apply the texture to each chunk, it uses a shader that determins what texture should be applied based on the world position of each pixel.

The picture shows many chunks being placed in the players rendering distance, as the player traverses towards the edge of the generated chunks, the ones furthest away from the player are hidden and new ones are generated or shown infront of the player to have a seeming endless landscape.

![image](https://user-images.githubusercontent.com/32739337/99461091-789d0b80-2907-11eb-91eb-21bd00bf0ecd.png)

## Level of Detail over Distance
Depending on the distance of each chunk from the player, the number of vertices can be lowered for better performance. Mesh near the player is created with a higher amount of vertices compared to mesh further away from players.  

With three different Level of Detail settings, you can see the visible difference in the Triangle count, this allows for a boost in performance with an almost unnoticable change.
![image](https://user-images.githubusercontent.com/32739337/100610136-88442900-32e5-11eb-80d1-a1c360a25790.png)
This image has 2 different level of detail meshs pictured, the border of the chunk with the lower level of detail. 
![image](https://user-images.githubusercontent.com/32739337/100557763-8183ca80-3281-11eb-9bc4-1f8386a82349.png)

## Seamless Chunk Borders
 This caused issues with the border each chunk not properly aligning  with a chunk with less verticies. It wasn't a big issue but sometimes in the distance it wouldn't look smooth and would break immersion. The solution to this was to create a high detail border so that each chunk, no matter the detail was using the same border quality, allowing for a smooth and seamless terrain.       
![image](https://user-images.githubusercontent.com/32739337/100557982-aaf12600-3282-11eb-83ec-dc7047e93cad.png)

## FlatShading
![image](https://user-images.githubusercontent.com/32739337/100622232-ffce8400-32f6-11eb-995c-4b10dde1daac.png)
I have also implemented FlatShading, giving a lower poly look. 



