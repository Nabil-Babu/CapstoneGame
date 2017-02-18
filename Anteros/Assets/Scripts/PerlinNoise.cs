﻿using UnityEngine;
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
		int sampleIndex = 16;

		float noise = 0; 

		range /= 2;

		while (sampleIndex > 0) {
			int index_x = x / sampleIndex;
			int index_y = y / sampleIndex;

			float t_x = (Mathf.Abs(x) % sampleIndex) / (sampleIndex * 1f); //1f turns it into a float
			float t_y = (Mathf.Abs(y) % sampleIndex) / (sampleIndex * 1f);

			if (x < 0) {
				t_x = 1 - t_x;
				index_x--;
			}

			if (y < 0) {
				t_y = 1 - t_y;
				index_y--;
			}

			float r_00 = random(index_x, index_y, range);
			float r_01 = random(index_x, index_y + 1, range);
			float r_10 = random(index_x + 1, index_y, range);
			float r_11 = random(index_x + 1, index_y + 1, range);

			float r_0 = lerp (r_00, r_01, t_y);
			float r_1 = lerp (r_10, r_11, t_y);

			float r = lerp (r_0, r_1, t_x);

			noise += r;

			sampleIndex /= 2;
			range /= 2;

			range = Mathf.Max (1, range); //makes sure range can't be zero
		}


		return (int)Mathf.Round(noise);
	}

	private float lerp(float l, float r, float t) {
		return l * (1 - t) + r * t; 
	}

	public int getSeed(){
		return seed;
	}
}
