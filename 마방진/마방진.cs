using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 마방진
{
	class Program
	{
		static void Main(string[] args)
		{
			int[,] magic;
			int val = 1;
			int size;
			int row = 0;
			int col;

			Console.Write("마방진 사이즈 입력 (홀수) : ");
			Console.WriteLine($"사이즈는 {size=int.Parse(Console.ReadLine())}x{size} 입니다");
			magic = new int[size, size];
			col = size / 2;						// 1은 열의 맨 처음 정중앙에 위치
			while (val <= Math.Pow(size, 2)) {  // 마방진의 크기만큼 반복
				magic[row, col] = val;          // 맨 처음 1열 중앙에 1 할당 이후 아래 방식에 의해 val값이 할당됨
				if (val % size == 0) row++;     // val과 size를 나눈 나머지가 0이면 행 증가 (↓)
				else {
					row--; col++;               // 그 외엔 행 감소 열 증가 (↑→)
				}
				if (row < 0) row = size - 1;    // 행이 1행이라면 맨 마지막 행으로 이동
				if (col >= size) col = 0;       // 열이 우측최대라면 맨 왼쪽 열로 이동
				val++;
			}
			for(int i = 0; i < size; i++) {     // 마방진 출력
				for(int j = 0; j < size; j++)
					Console.Write(magic[i, j] + " ");
				Console.WriteLine();
			}
		}
	}
}
