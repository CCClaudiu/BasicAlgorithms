// LIS.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
#include<fstream>
using namespace std;
int* LIS(int* a, int n)
{
	int* lung = new int[n];
	lung[n - 1] = 1;
	for (int i = n - 2; i >= 0; i--)
	{
		int maxim = 0;
		for (int j = i + 1; j <= n - 1; j++)
		{
			if (a[i] <= a[j])
			{
				if (maxim<lung[j])
					maxim = lung[j];
			}
		}
		lung[i] = maxim + 1;
	}
	return lung;

}
void Scriere(int *a, int n, int* lung)
{
	int maxim = lung[0];
	int poz = 0;
	for (int i = 1; i<n; i++)
	{
		if (maxim <= lung[i])
		{
			maxim = lung[i];
			poz = i;
		}
	}
	cout << "Lungimea maxima a subsecventei:" << maxim << endl;
	cout << "Subsecventa este:" << a[poz] << " ";
	for (int i = poz + 1; i <= n - 1; i++)
	{
		/*if(lung[i]==lung[i-1])
		{
		cout<<a[i]<<" ";
		poz=i;
		maxim=maxim-1;
		if(maxim==0)
		break;
		}*/
		if (lung[i] == maxim - 1 && a[i] >= a[poz])
		{
			cout << a[i] << " ";
			poz = i;
			maxim = maxim - 1;
			if (maxim == 0)
				break;
		}
	}
}
int main()
{
	int* v;
	int*subs;
	int n;
	ifstream fin;
	ofstream fout;
	fin.open("date.txt", ios::in);
	fout.open("output.txt", ios::out);
	if (fin.fail() || fout.fail())
	{
		cout << "Eroare la deschidere" << endl;
	}
	fin >> n;
	v = new int[n];
	for (int i = 0; i<n; i++)
	{
		fin >> v[i];
	}
	cout << n << endl;
	for (int i = 0; i<n; i++)
		cout << v[i] << " ";
	cout << endl;
	subs = LIS(v, n);
	for (int i = 0; i<n; i++)
		cout << subs[i] << " ";
	cout << endl;
	Scriere(v, n, subs);
	fin.close();
	fout.close();
	getchar();
	return 0;
}

