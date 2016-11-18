using UnityEngine;
using System.Collections;

public class PerlinNoise{
	int seed; 

	public PerlinNoise (int seed){
		this.seed = seed; 
	}

	private int random(int x, int range){
		Random.InitState (seed+x);
		return Random.Range (0, range);
		//return (int)((x+seed)^5) %  range;
	}

	private int random(int x, int y, int range){
		return random (x + y * 65536, range); 
	}

	public int getNoise(int x, int y, int range){
		int chunkSize = 16;

		float noise = 0; 

		range /= 2;

		while (chunkSize > 0) {
			int index_x = x / chunkSize;
			int index_y = y / chunkSize;

			float t_x = (x % chunkSize) / (chunkSize * 1f); //1f turns it into a float
			float t_y = (y % chunkSize) / (chunkSize * 1f);

			float r_00 = random(index_x, index_y, range);
			float r_01 = random(index_x, index_y + 1, range);
			float r_10 = random(index_x + 1, index_y, range);
			float r_11 = random(index_x + 1, index_y + 1, range);

			float r_0 = lerp (r_00, r_01, t_y);
			float r_1 = lerp (r_10, r_11, t_y);

			float r = lerp (r_0, r_1, t_x);

			noise += r;

			chunkSize /= 2;
			range /= 2;

			range = Mathf.Max (1, range); //makes sure range can't be zero
		}


		return (int)Mathf.Round(noise);
	}

	private float lerp(float l, float r, float t) {
		return l * (1 - t) + r * t; 
	}
}
