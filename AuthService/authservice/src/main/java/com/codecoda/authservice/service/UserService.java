package com.codecoda.authservice.service;

import com.codecoda.authservice.models.User;

import java.util.List;

public interface UserService {

    List<User> findAll();

    User findById(int theId);

    User findByUsername(String username);

    User findByEmail(String email);

    void save(User theUser);

    void deleteById(int theId);

    boolean existsByUsername(String username);

    boolean existsByEmail(String email);


}
