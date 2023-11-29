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

class linkable {
public:
	virtual void set_next(linkable*) = 0;
	virtual linkable* get_next() = 0;
};

class drawable {
public:
	virtual void draw() = 0;
};

class moveable {
public:
	virtual void move(int, int) = 0;
};

// фигура
class figure : public drawable, public linkable, public moveable {
	int x, y;
public:
	linkable* next;
	figure(int a, int b) : x(a), y(b), next(0) {}
	// Чистая виртуальная функция
	// т.е. figure - абстрактный класс
	virtual void draw() = 0;
	void move(int a, int b) {
		x = a;
		y = b;
	}
	int getX() { return x; }
	int getY() { return y; }
	void set_next(linkable* a) {
		next = static_cast<figure*>(a);
	}
	linkable *get_next() {
		return static_cast<linkable*>(next);
	}
};

// кружок
class circle : public figure {
public:
	circle(int a = 0, int b = 0) : figure(a, b) {}
	void draw() {
		printf("circle\n");
	}
};

// квадрат
class square : public figure {
public:
	square(int a = 0, int b = 0) : figure(a, b) {}
	void draw() {
		printf("square\n");
	}
};

#define BASECLASS linkable
class paintapp {
	BASECLASS* first;
public:
	paintapp() : first(0) {}
	void add(BASECLASS* ob) {
		assert(dynamic_cast<drawable*>(ob));
		if (first == 0) {
			first = ob;
		}
		else {
			BASECLASS* temp = first;
			while (temp->get_next()) {
				temp = temp->get_next();
			}
			temp->set_next(ob);
		}
	}
	void draw() {
		BASECLASS* temp = first;
		while (temp) {
			dynamic_cast<drawable*>(temp)->draw();
			temp = temp->get_next();
		}
	}
	BASECLASS* item(int index) {
		index = abs(index);
		assert(first != NULL);
		BASECLASS* temp = first;
		while (temp) {
			if (--index == 0) return temp;
			temp = temp->get_next();
		}
		int index_overflow = 0;
		assert(index_overflow);
	}
};

struct text : public drawable, public linkable {
	linkable* next;
	text() : next(0) {}
	void set_next(linkable* a) {
		next = a;
	}
	linkable* get_next() {
		return next;
	}
	void draw() {
		printf("text\n");
	}
};