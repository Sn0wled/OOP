/* 2018 ReVoL Primer Template */
/* class.h */
#pragma once
#define _CRT_SECURE_NO_WARNINGS
#include <assert.h>
#include <stdio.h>
#include <math.h>
#include <string.h>
#include <iostream>
using namespace std;

const int MAX_OBJECT = 4;

struct point {
	int x, y;
	point() : x(0), y(0) {}
};

class figure {
protected:
	point tl;
public:
	virtual void draw() {
		printf("f(%d, %d)\n", tl.x, tl.y);
	}
	virtual void location() {
		printf("(%d, %d)", tl.x, tl.y);
	}
	int getX() { return tl.x; }
	int getY() { return tl.y; }
};

class circle : public figure {
public:
	circle() {}
	void draw() {
		printf("c(%d, %d)\n", tl.x, tl.y);
	}
};

class square : public figure {
public:
	square() {}
	void draw() {
		printf("s(%d, %d)\n", tl.x, tl.y);
	}

};

class paintapp {
	int count;
	figure* g[MAX_OBJECT];
	int t[MAX_OBJECT];
public:
	paintapp() : count(0), g() {}
	void add(figure* a) {
		assert(count < MAX_OBJECT);
		g[count] = a;
		count++;
	}
	void add_c(circle* a) {
		assert(count < MAX_OBJECT);
		t[count] = 1;
		g[count++] = a;
	}
	void add_s(square* a) {
		assert(count < MAX_OBJECT);
		t[count] = 2;
		g[count++] = a;
	}
	void draw() {
		for (int i = 0; i < count; i++) {
			g[i]->draw();
		}
	}
	void drawt() {
		for (int i = 0; i < count; i++) {
			if (t[i] == 1) {
				((circle*)g[i])->draw();
			}
			else if (t[i] == 2) {
				((square*)g[i])->draw();
			}
			else {
				((figure*)g[i])->draw();
			}
		}
	}
};