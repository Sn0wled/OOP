/* 2018 ReVoL Primer Template */
/* class.h */
#pragma once
#define _CRT_SECURE_NO_WARNINGS
#include <assert.h>
#include <stdio.h>
#include <math.h>
#include <string.h>
#include <iostream>
//using namespace std;

struct point {
	int x, y;
	point(int a = 0, int b = 0) : x(a), y(b) {}
};

template <class T>
void swap(T& a, T& b) {
	T c = a;
	a = b;
	b = c;
}

template <class T>
void bsort(T* a, int size, int (*cfunc)(T a, T b)) {
	for (int i = 1; i < size; i++) {
		for (int j = 1; j < size; j++) {
			if (cfunc(a[j - 1], a[j])) {
				swap(a[j - 1], a[j]);
			}
		}
	}
}

template <class T>
int compare_number(T a, T b) {
	return a > b;
}

int compare_points(point a, point b) {
	return (a.x + a.y) > (b.x + b.y);
}

template <class T, int N>
class Array {
	T a[N];
public:
	Array() {
		for (int i = 0; i < N; i++) a[i] = 0;
	}
	int& operator [] (int index) {
		assert(index >= 0 && index < N);
		return a[index];
	}
};


template <class T, int N>
class tstack {
	T a[10];
	int count;
public:
	tstack();
	int size();
	void push(T element);
	T pop();
	T top();
};

template <class T, int N>
tstack<T, N>::tstack() {
	count = 0;
	for (int i = 0; i < N; i++) a[i] = 0;
}

template <class T, int N>
int tstack<T, N>::size() {
	return count;
}

template <class T, int N>
void tstack<T, N>::push(T element) {
	assert(count < N);
	a[count++] = element;
}

template <class T, int N>
T tstack<T, N>::pop() {
	assert(count > 0);
	return a[--count];
}

template <class T, int N>
T tstack<T, N>::top() {
	assert(count > 0);
	return a[count - 1];
}
