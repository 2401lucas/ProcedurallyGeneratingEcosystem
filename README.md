![image](https://user-images.githubusercontent.com/32739337/100557612-b5aabb80-3280-11eb-8201-1706ba5f9f4d.png)
# Procedural Ecosystem
This Project is an endlessly generating procedural landscape with mountains, trees, grass, water and animals. 

## The Terrain Generation
There is a Chunk of terrain that is created using Unity's Perlin noise algorithm to generate random values between 0-1, then a height curve is applied to create flat water and steep hills. 

To apply the texture to each chunk, it uses a shader that determins what texture should be applied based on the world position of each pixel.

The picture shows many chunks being placed in the players rendering distance, as the player traverses towards the edge of the generated chunks, the ones furthest away from the player are hidden and new ones are generated or shown infront of the player to have a seeming endless landscape.

![image](https://user-images.githubusercontent.com/32739337/99461091-789d0b80-2907-11eb-91eb-21bd00bf0ecd.png)


## Seamless Chunk Borders
Depending on the distance of each chunk the number of vertices can be lowered for better performance. This caused issues with the border of the terrain mesh not aligning with  
![image](https://user-images.githubusercontent.com/32739337/100557982-aaf12600-3282-11eb-83ec-dc7047e93cad.png)


![image](https://user-images.githubusercontent.com/32739337/100557763-8183ca80-3281-11eb-9bc4-1f8386a82349.png)
