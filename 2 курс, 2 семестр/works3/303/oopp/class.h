/* 2018 ReVoL Primer Template */
/* class.h */
#pragma once
#define _CRT_SECURE_NO_WARNINGS
#include <assert.h>
#include <stdio.h>
#include <math.h>
#include <string.h>
#include <iostream>
#include <errno.h>
#include <Windows.h>
using namespace std;

struct file_error {
	string msg;
	file_error(LPCSTR m) : msg(m) {
		cout << "\nconstructor\n\n";
	}
	LPCSTR message() {
		return msg.c_str();
	}
};

struct fe_no_path : public file_error {
	fe_no_path() : file_error("No such file or directory") {}
};

struct fe_access_denied : public file_error {
	fe_access_denied() : file_error("Access denied") {}
};

struct fe_invalid_arg : public file_error {
	fe_invalid_arg() : file_error("Invalid arguments") {}
};


class gen_err { virtual void foo() {} };
class file_err : public gen_err {};
class file_open_err : public file_err {};
class file_read_err : public file_err {};
class array_err : public gen_err {};
class array_bound_err : public array_err {};
class array_overflow_err : public array_err {};

struct m_class {
	char* a, * b;
	m_class(const char* a, const char* b) {
		__try {
			a = new char[20];
			throw 1;
		}
		__finally {
			cout << "in finally\n";
			delete[] a;
		}
	}
	~m_class() {
		cout << "in ~m_class()\n";
		if (a) delete[] a;
	}
};