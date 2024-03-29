// Combinations.cpp : Defines the entry point for the console application.
//
#include "stdafx.h"
#include <iostream>
#include<fstream>
#include <windows.h>
using namespace std;

int Factorial(int n)
{
	int p = 1;
	for (int i = 1; i <= n; i++)
	{
		p = p * i;
	}
	return p;
}
long Combinari_v1(int n, int k)
{
	return Factorial(n) / (Factorial(k)*Factorial(n - k));
}
long Combinari_v2(int n, int k)
{
	if (k == 0)
		return 1;
	if (n == k)
		return 1;
	return Combinari_v2(n - 1, k) + Combinari_v2(n - 1, k - 1);
}
long Combinari_v3(int n, int k)
{
	if (k == 0 || k == n)
		return 1;
	if (k == n - 1)
		return n;
	int** a = 0;
	a = new int*[n + 1];
	for (int i = 0; i <= n + 1; i++)
	{
		a[i] = new int[k + 1];
	}
	for (int i = 0; i<n + 1; i++)
	{
		//cout<<endl;
		for (int j = 0; j<k + 1; j++)
			a[i][j] = 0;
	}
	a[0][0] = 1;
	a[1][0] = 1;
	a[1][1] = 1;
	for (int i = 2; i <= n; i++)
	{
		a[i][0] = 1;
		a[i][i] = 1;
		for (int j = 1; j <= i - 1; j++)
		{
			a[i][j] = a[i - 1][j - 1] + a[i - 1][j];
		}
	}
	cout << endl;
	for (int i = 0; i<n + 1; i++)
	{
		cout << endl;
		for (int j = 0; j<k + 1; j++)
			cout << a[i][j] << " ";

	}
	cout << "\n" << endl;

	return a[n][k];



}
long Combinari_v4(int n, int k)
{
	if (k == 0 || k == n)
		return 1;
	if (k == n - 1)
		return n;
	int* ant = new int[k + 2];
	int* curent = new int[k + 2];
	ant[0] = 1;
	ant[1] = 1;
	for (int i = 2; i <= n; i++)
	{
		curent[0] = 1;
		//if(i<=k)
		//   curent[i]=1;
		int limit = min(i - 1, k);
		for (int j = 1; j <= limit; j++)
		{
			curent[j] = ant[j - 1] + ant[j];
			//cout<<curent[j]<<" ";
		}
		//cout<<endl;
		for (int k = 1; k <= limit + 1; k++)
		{
			ant[k] = curent[k];

		}


	}
	/*cout<<"---------------------------------"<<endl;
	for(int i=0;i<k+1;i++)
	{
	cout<<ant[i]<<" ";
	//cout<<curent[i]<<endl;
	}
	cout<<endl;
	for(int i=0;i<k+1;i++)
	{
	//cout<<ant[i]<<" ";
	cout<<curent[i]<<" ";
	}

	cout<<"---------------------------------"<<endl;*/
	return curent[k];
}
int main()
{
	//int* v;
	int n, k;
	ifstream fin;
	ofstream fout;
	fin.open("date.txt", ios::in);
	fout.open("output.txt", ios::out);
	if (fin.fail() || fout.fail())
	{
		cout << "Eroare la deschidere" << endl;

	}
	for (int i = 0; i<4; i++)
	{
		fin >> n >> k;

		cout << "C1(" << n << "," << k << ")=" << Combinari_v1(n, k) << endl;
		cout << "C2(" << n << "," << k << ")=" << Combinari_v2(n, k) << endl;
		cout << "C3(" << n << "," << k << ")=" << Combinari_v3(n, k) << endl;
		cout << "C4(" << n << "," << k << ")=" << Combinari_v4(n, k) << endl;
	}
	fin.close();
	fout.close();
	getchar();
	return 0;
}

