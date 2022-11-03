package one.digitalinnovation.parking.service;

import one.digitalinnovation.parking.exception.ParkingNotFoundException;
import one.digitalinnovation.parking.model.Parking;
import one.digitalinnovation.parking.repository.IParkingRepository;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Propagation;
import org.springframework.transaction.annotation.Transactional;

import java.time.LocalDateTime;
import java.time.temporal.ChronoUnit;
import java.util.*;
import java.util.stream.Collectors;

@Service
public class ParkingService {

    private final IParkingRepository parkingRepository;

    public ParkingService(IParkingRepository parkingRepository) {
        this.parkingRepository = parkingRepository;
    }

    @Transactional(readOnly = true, propagation = Propagation.SUPPORTS)
    public List<Parking> findAll(){
        return parkingRepository.findAll();
    }

    private static String getUUID() {
        return UUID.randomUUID().toString().replace("-", "");
    }

    @Transactional(readOnly = true)
    public Parking findById(String id) {
        return parkingRepository.findById(id).orElseThrow(() -> new ParkingNotFoundException(id));
    }

    @Transactional
    public Parking create(Parking parkingCreate) {
        String uuid = getUUID();
        parkingCreate.setId(uuid);
        parkingCreate.setEntryDate(LocalDateTime.now());
        parkingRepository.save(parkingCreate);
        return parkingCreate;
    }

    @Transactional
    public void delete(String id) {
        //If not found, it will throw an exception automatically
        findById(id);
        parkingRepository.deleteById(id);
    }

    @Transactional
    public Parking update(String id, Parking parkingCreate) {
        //If not found, it will throw an exception automatically
        Parking parking = findById(id);
        parking.setColor(parkingCreate.getColor());
        parking.setState(parkingCreate.getState());
        parking.setLicense(parkingCreate.getLicense());
        parking.setModel(parkingCreate.getModel());

        parkingRepository.save(parking);
        return parking;
    }

    @Transactional
    public Parking exit(String id) {
        Parking parking = findById(id);
        parking.setExitDate(LocalDateTime.now());

        LocalDateTime entry = parking.getEntryDate();
        LocalDateTime exit = parking.getExitDate();
        long diffInMinutes = ChronoUnit.MINUTES.between(entry, exit);
        var value = 0.00;

        if (diffInMinutes % 60 <= 0) {
            value = 5.00;
        }
        else {
            value = (diffInMinutes % 60) * 5.00;
        }
        parking.setBill(value);

        parkingRepository.save(parking);
        return parking;
    }
}

